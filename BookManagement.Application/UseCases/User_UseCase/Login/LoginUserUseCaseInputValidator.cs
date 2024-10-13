using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.Login
{
    public class LoginUserUseCaseInputValidator : AbstractValidator<LoginUserUseCaseInput>
    {
        public LoginUserUseCaseInputValidator()
        {
            RuleFor(x => x.Email)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Email should be has value");
            RuleFor(x => x.Password)
                .Must(x => !string.IsNullOrEmpty(x))
                .WithMessage("Password should be has value");
        }
    }
}
