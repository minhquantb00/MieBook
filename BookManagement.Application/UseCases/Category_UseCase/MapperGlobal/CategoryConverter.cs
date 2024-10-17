using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.MapperGlobal
{
    public class CategoryConverter
    {
        public DataResponseCategory EntityToDTO(Category category)
        {
            return new DataResponseCategory
            {
                Id = category.Id,
                Name = category.Name,
                NumberOfProducts = category.NumberOfProducts,
            };
        }
    }
}
