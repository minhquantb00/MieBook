using BookManagement.Application.IUseCases;
using BookManagement.Commons.UtilitiesGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.ChangePassword
{
    public class ChangePasswordUseCase : IUseCase<ChangePasswordUseCaseInput, ChangePasswordUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public ChangePasswordUseCase(IRepository<User> userRepository, IHttpContextAccessor contextAccessor)
        {
            _userRepository = userRepository;
            _contextAccessor = contextAccessor;
        }
        public async Task<ChangePasswordUseCaseOutput> ExcuteAsync(ChangePasswordUseCaseInput input)
        {
            ChangePasswordUseCaseOutput result = new ChangePasswordUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            string userId = currentUser.FindFirst("Id").Value;
            if (string.IsNullOrEmpty(userId))
            {
                result.Errors = new string[] { "Thông tin người dùng không hợp lệ" };
            }
            var user = await _userRepository.GetAsync(item => item.Id == long.Parse(userId));
            if (!Utilities.IsPasswordValid(input.OldPassword, user.Password))
            {
                result.Errors = new string[] { "Mật khẩu không chính xác" };
                return result;
            }
            if (!input.NewPassword.Equals(input.ConfirmPassword))
            {
                result.Errors = new string[] { "Mật khẩu không trùng khớp" };
                return result;
            }
            try
            {
                user.Password = Utilities.HashPassword(input.NewPassword);
                user.UpdateTime = DateTime.Now;
                user = await _userRepository.UpdateAsync(user);
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
