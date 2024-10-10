using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.Register
{
    public class RegisterUserUseCase : IUseCases.IUseCase<RegisterUserUseCaseInput, RegisterUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository<Role> _roleRepository;
        public RegisterUserUseCase(IRepository<User> userRepository, IHttpContextAccessor httpContextAccessor, IRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _roleRepository = roleRepository;
        }

        public async Task<RegisterUserUseCaseOutput> ExcuteAsync(RegisterUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<RegisterUserUseCaseOutput> ExcuteAsync(int? id, RegisterUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
