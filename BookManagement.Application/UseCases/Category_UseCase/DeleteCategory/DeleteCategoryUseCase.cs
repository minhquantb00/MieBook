using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.DeleteCategory
{
    public class DeleteCategoryUseCase : IUseCase<DeleteCategoryUseCaseInput, DeleteCategoryUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteCategoryUseCase(IRepository<User> userRepository, IRepository<Category> categoryRepository, IHttpContextAccessor contextAccessor, IRepository<Book> bookRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
        }
        public async Task<DeleteCategoryUseCaseOutput> ExcuteAsync(DeleteCategoryUseCaseInput input)
        {
            DeleteCategoryUseCaseOutput result = new DeleteCategoryUseCaseOutput
            {
                Succeeded = false
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
                var category = await _categoryRepository.GetByIdAsync(input.Id);
                if (category == null)
                {
                    result.Errors = new string[] { "Danh mục không tồn tại" };
                    return result;
                }

                await _categoryRepository.DeleteAsync(category.Id);
                result.Succeeded = true;
                return result;

            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<DeleteCategoryUseCaseOutput> ExcuteAsync(long? id, DeleteCategoryUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
