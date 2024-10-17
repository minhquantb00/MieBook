using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Category_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.GetCategoryById
{
    public class GetCategoryByIdUseCase : IUseCaseGetById<long, GetCategoryByIdUseCaseOutput>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly CategoryConverter _categoryConverter;
        public GetCategoryByIdUseCase(IRepository<Category> categoryRepository, CategoryConverter categoryConverter)
        {
            _categoryRepository = categoryRepository;
            _categoryConverter = categoryConverter;
        }
        public async Task<GetCategoryByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetCategoryByIdUseCaseOutput result = new GetCategoryByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _categoryRepository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Danh mục không tồn tại" };
                return result;
            }
            result.Succeeded = true;
            result.DataResponseCategory = _categoryConverter.EntityToDTO(query);
            return result;
        }
    }
}
