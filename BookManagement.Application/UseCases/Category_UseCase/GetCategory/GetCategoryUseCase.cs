using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Category_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.GetCategory
{
    public class GetCategoryUseCase : IUseCase<GetCategoryUseCaseInput, GetCategoryUseCaseOutput>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly CategoryConverter _categoryConverter;
        
        public GetCategoryUseCase(IRepository<Category> categoryRepository, CategoryConverter categoryConverter)
        {
            _categoryRepository = categoryRepository;
            _categoryConverter = categoryConverter;
        }
        public async Task<GetCategoryUseCaseOutput> ExcuteAsync(GetCategoryUseCaseInput input)
        {
            GetCategoryUseCaseOutput result = new GetCategoryUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _categoryRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.AsNoTracking().Where(record => record.Name.Contains(input.Name));
            }
            result.Succeeded = true;
            result.DataResponseCategories = query.AsNoTracking().Select(item => _categoryConverter.EntityToDTO(item));
            return result;
        }
    }
}
