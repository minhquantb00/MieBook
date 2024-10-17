using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Category_UseCase.CreateCategory
{
    public class CreateCategoryUseCaseInput
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
