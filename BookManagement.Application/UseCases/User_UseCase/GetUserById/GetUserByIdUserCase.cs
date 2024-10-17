using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.GetUserById
{
    public class GetUserByIdUserCase : IUseCaseGetById<long, GetUserByIdUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserConverter _converter;
        public GetUserByIdUserCase(IRepository<User> userRepository, UserConverter converter)
        {
            _userRepository = userRepository;
            _converter = converter;
        }
        public async Task<GetUserByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetUserByIdUseCaseOutput result = new GetUserByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var user = await _userRepository.GetByIdAsync(id);
            if(user == null)
            {
                result.Errors = new string[] { "Thông tin người dùng không tồn tại" };
                return result;
            }
            result.DataResponseUser = _converter.EntityToDTO(user);
            result.Succeeded = true;
            return result;
        }
    }
}
