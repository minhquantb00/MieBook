using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.CreateCategory
{
    public class CreateCategoryUseCase : IUseCase<CreateCategoryUseCaseInput, CreateCategoryUseCaseOutput>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateCategoryUseCase(IRepository<Category> categoryRepository, IRepository<User> userRepository, IHttpContextAccessor contextAccessor)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }
        public async Task<CreateCategoryUseCaseOutput> ExcuteAsync(CreateCategoryUseCaseInput input)
        {
            CreateCategoryUseCaseOutput result = new CreateCategoryUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            if (!currentUser.IsInRole("Admin"))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            try
            {
                Category category = new Category
                {
                    CreateTime = DateTime.Now,
                    Name = input.Name,
                    NumberOfProducts = 0,
                };
                category = await _categoryRepository.CreateAsync(category);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
