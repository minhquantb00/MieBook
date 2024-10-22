using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.CreateShippingMethod
{
    public class CreateShippingMethodUseCaseInput
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
