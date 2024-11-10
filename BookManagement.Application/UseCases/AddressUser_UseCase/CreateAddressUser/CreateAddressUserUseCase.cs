using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.CreateAddressUser
{
    public class CreateAddressUserUseCase : IUseCase<CreateAddressUserUseCaseInput, CreateAddressUserUseCaseOutput>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<AddressUser> _addressUserRepository;
        public CreateAddressUserUseCase(IHttpContextAccessor contextAccessor, IRepository<User> userRepository, IRepository<AddressUser> addressUserRepository)
        {
            _contextAccessor = contextAccessor;
            _userRepository = userRepository;
            _addressUserRepository = addressUserRepository;
        }

        public async Task<CreateAddressUserUseCaseOutput> ExcuteAsync(CreateAddressUserUseCaseInput input)
        {
            CreateAddressUserUseCaseOutput result = new CreateAddressUserUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _contextAccessor.HttpContext.User;
            string userId = currentUser.FindFirst("Id").Value;
            var user = await _userRepository.GetByIdAsync(long.Parse(userId));
            if (user == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu người dùng" };
                return result;
            }
            if(!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa đwọc xác thực" };
                return result;
            }
            try
            {
                AddressUser addressUser = new AddressUser
                {
                    UserId = long.Parse(userId),
                    Address = input.Address,
                    IsDefault = false,
                };
                addressUser = await _addressUserRepository.CreateAsync(addressUser);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
