using BookManagement.Commons.UtilitiesGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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
            RegisterUserUseCaseOutput output = new RegisterUserUseCaseOutput
            {
                Succeeded = false,
            };
            var checkEmail = await _userRepository.GetAsync(item => item.Email.Equals(input.Email));
            if(checkEmail != null)
            {
                output.Errors = new string[] { "Email này đã tồn tại trong hệ thống" };
                return output;
            }
            var checkPhoneNumber = await _userRepository.GetAsync(item => item.PhoneNumber.Equals(input.PhoneNumber));
            if (checkPhoneNumber != null)
            {
                output.Errors = new string[] { "Số điện thoại này đã tồn tại" };
                return output;
            }
            try
            {
                User user = new User
                {
                    IsActive = true,
                    CreateTime = DateTime.Now,
                    FullName = input.FullName,
                    Email = input.Email,
                    Gender = input.Gender,
                    IsDeleted = false,
                    NickName = "Hú hú",
                    Password = Utilities.HashPassword(input.Password),
                    PhoneNumber = input.PhoneNumber,
                    PinCode = "BookManagement",
                    Point = 0,
                };
                user = await _userRepository.CreateAsync(user);
                if (user == null)
                {
                    output.Errors = new string[] { "Đăng ký người dùng không thành công!" };
                    return output;
                }
                await _userRepository.AddUserToRoleAsync(user, new string[] { "User" });
                output.Succeeded = true;
                return output;
            }
            catch (Exception ex)
            {
                output.Errors = new string[] { ex.Message };
                return output;
            }
        }

        public Task<RegisterUserUseCaseOutput> ExcuteAsync(int? id, RegisterUserUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
