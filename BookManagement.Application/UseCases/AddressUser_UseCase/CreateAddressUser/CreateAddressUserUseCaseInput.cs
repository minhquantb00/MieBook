using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.CreateAddressUser
{
    public class CreateAddressUserUseCaseInput
    {
        [Required(ErrorMessage = "Address is required")]
        public string Address {  get; set; }
    }
}
