using BookManagement.Application.Handle.Email;
using BookManagement.Application.IUseCases;
using BookManagement.Commons.UtilitiesGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.ConfirmCreateNewPassword
{
    public class ConfirmCreateNewPasswordUseCase : IUseCase<ConfirmCreateNewPasswordUseCaseInput, ConfirmCreateNewPasswordUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
        private readonly IEmailService _emailService;
        public ConfirmCreateNewPasswordUseCase(IRepository<User> userRepository, IEmailService emailService, IRepository<ConfirmEmail> confirmEmailRepository)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _confirmEmailRepository = confirmEmailRepository;
        }
        public async Task<ConfirmCreateNewPasswordUseCaseOutput> ExcuteAsync(ConfirmCreateNewPasswordUseCaseInput input)
        {
            ConfirmCreateNewPasswordUseCaseOutput result = new ConfirmCreateNewPasswordUseCaseOutput
            {
                Succeeded = false,
            };
            var confirmEmail = await _confirmEmailRepository.GetAsync(item => item.ConfirmCode.Equals(input.ConfirmCode));
            if(confirmEmail == null)
            {
                result.Errors = new string[] { "Mã xác nhận không hợp lệ" };
                return result;
            }
            var user = await _userRepository.GetAsync(item => item.Id == confirmEmail.UserId);
            if(user == null)
            {
                result.Errors = new string[] { "Người dùng không tồn tại" };
                return result;
            }
            if (!input.NewPassword.Equals(input.ConfirmNewPassword))
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
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }

        }

        public Task<ConfirmCreateNewPasswordUseCaseOutput> ExcuteAsync(long? id, ConfirmCreateNewPasswordUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
