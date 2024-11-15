using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.MapperGlobal
{
    public class CategoryConverter
    {
        private readonly IRepository<Book> _bookRepository;
        public CategoryConverter(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public DataResponseCategory EntityToDTO(Category category)
        {
            int numberOfProducts = _bookRepository.GetAllAsync(item => item.CategoryId == category.Id).Result.Count();
            return new DataResponseCategory
            {
                Id = category.Id,
                Name = category.Name,
                NumberOfProducts = numberOfProducts == 0 ? 0 : numberOfProducts,
            };
        }
    }
}
