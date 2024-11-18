using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.IUseCases
{
    public interface IUseCasePayment<TUseCaseInput, TUseCaseOutput> where TUseCaseInput : class where TUseCaseOutput : class
    {
        Task<TUseCaseOutput> ExcuteAsync(TUseCaseInput input, HttpContext httpContext);
    }
}
