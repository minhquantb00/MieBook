using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Category_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.GetCategory
{
    public class GetCategoryUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseCategory> DataResponseCategories { get; set; }
    }
}
