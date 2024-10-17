using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.UpdateCategory
{
    public class UpdateCategoryUseCase : IUseCase<UpdateCategoryUseCaseInput, UpdateCategoryUseCaseOutput>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<Category> _categoryRepository;
        public UpdateCategoryUseCase(IHttpContextAccessor contextAccessor, IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
        }
        public async Task<UpdateCategoryUseCaseOutput> ExcuteAsync(UpdateCategoryUseCaseInput input)
        {
            UpdateCategoryUseCaseOutput result = new UpdateCategoryUseCaseOutput
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
                var category = await _categoryRepository.GetAsync(item => item.Id == input.Id);
                if (category == null)
                {
                    result.Errors = new string[] { "Danh mục không tồn tại" };
                    return result;
                }
                category.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : category.Name;
                category.UpdateTime = DateTime.Now;
                category = await _categoryRepository.UpdateAsync(category);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
            
        }

        public async Task<UpdateCategoryUseCaseOutput> ExcuteAsync(long? id, UpdateCategoryUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
