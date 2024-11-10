using BookManagement.Application.Handle.Email;
using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.User_UseCase.ForgotPassword
{
    public class ForgotPasswordUseCase : IUseCase<ForgotPasswordUseCaseInput, ForgotPasswordUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ConfirmEmail> _confirmEmailRepository;
        private readonly IEmailService _emailService;
        public ForgotPasswordUseCase(IRepository<User> userRepository, IEmailService emailService, IRepository<ConfirmEmail> confirmEmailRepository)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _confirmEmailRepository = confirmEmailRepository;
        }
        public async Task<ForgotPasswordUseCaseOutput> ExcuteAsync(ForgotPasswordUseCaseInput input)
        {
            ForgotPasswordUseCaseOutput result = new ForgotPasswordUseCaseOutput
            {
                Succeeded = false,
            };
            var user = await _userRepository.GetAsync(item => item.Email.Equals(input.Email));
            if (user == null)
            {
                result.Errors = new string[] { "Email không tồn tại trong hệ thống" };
                return result;
            }
            try
            {
                ConfirmEmail confirmEmail = new ConfirmEmail
                {
                    ConfirmCode = "MieShop_" + DateTime.Now.Ticks.ToString(),
                    CreateTime = DateTime.Now,
                    ExpiredTime = DateTime.Now.AddMinutes(15),
                    IsConfirmed = false,
                    UserId = user.Id,
                };
                confirmEmail = await _confirmEmailRepository.CreateAsync(confirmEmail);
                var message = new Request_Message(new string[] { user.Email }, "Nhận mã xác nhận tại đây: ", $"Mã xác nhận là: {confirmEmail.ConfirmCode}");
                _emailService.SendEmail(message);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] {ex.Message};
                return result;
            }
        }
    }
}
