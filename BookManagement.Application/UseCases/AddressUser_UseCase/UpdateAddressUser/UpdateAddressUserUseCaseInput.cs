using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.UpdateAddressUser
{
    public class UpdateAddressUserUseCaseInput
    {
        public long Id { get; set; }
        public string? Address { get; set; }
    }
}
