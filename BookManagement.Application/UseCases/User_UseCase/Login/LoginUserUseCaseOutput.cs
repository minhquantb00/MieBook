using BookManagement.Application.OuputBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.Login
{
    public class LoginUserUseCaseOutput : UseCaseOutputBase
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
