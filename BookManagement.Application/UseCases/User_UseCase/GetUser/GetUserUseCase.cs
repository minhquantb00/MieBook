using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.GetUser
{
    public class GetUserUseCase : IUseCase<GetUserUseCaseInput, GetUserUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly UserConverter _userConverter;
        public GetUserUseCase(IRepository<User> userRepository, UserConverter userConverter)
        {
            _userConverter = userConverter;
            _userRepository = userRepository;
        }
        public async Task<GetUserUseCaseOutput> ExcuteAsync(GetUserUseCaseInput input)
        {
            GetUserUseCaseOutput response = new GetUserUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _userRepository.GetAllAsync(record => record.IsActive == true && record.IsDeleted == false);
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.Where(item =>item.Email.Equals(input.Keyword)
                                         || item.FullName.ToLower().Contains(input.Keyword.ToLower())
                                         || item.PhoneNumber.Trim().Equals(input.Keyword.Trim()));
            }
            response.Succeeded = true;
            response.DataResponseUser = query.Select(item => _userConverter.EntityToDTO(item));
            return response;
        }

        public Task<GetUserUseCaseOutput> ExcuteAsync(long? id, GetUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
