using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.Register
{
    public class RegisterUserUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseUser DataResponseUser { get; set; }
    }
}
