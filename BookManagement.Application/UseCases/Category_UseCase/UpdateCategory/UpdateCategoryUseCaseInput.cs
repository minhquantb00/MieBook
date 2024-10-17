using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.UpdateCategory
{
    public class UpdateCategoryUseCaseInput
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }
}
