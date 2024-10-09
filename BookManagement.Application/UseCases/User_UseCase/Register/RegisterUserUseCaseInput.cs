using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.Register
{
    public class RegisterUserUseCaseInput
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Upload)]
        public Enumerate.Gender? Gender { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
