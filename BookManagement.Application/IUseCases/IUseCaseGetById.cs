using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.IUseCases
{
    public interface IUseCaseGetById<T, TUseCaseOutput> where TUseCaseOutput : class
    {
        Task<TUseCaseOutput> ExcuteAsync(T id);
    }
}
