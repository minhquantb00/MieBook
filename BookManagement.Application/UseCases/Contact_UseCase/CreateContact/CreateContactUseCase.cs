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

namespace BookManagement.Application.UseCases.Contact_UseCase.CreateContact
{
    public class CreateContactUseCase : IUseCase<CreateContactUseCaseInput, CreateContactUseCaseOutput>
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateContactUseCase(IRepository<Contact> contactRepository, IHttpContextAccessor contextAccessor)
        {
            _contactRepository = contactRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<CreateContactUseCaseOutput> ExcuteAsync(CreateContactUseCaseInput input)
        {
            CreateContactUseCaseOutput result = new CreateContactUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            if (!currentUser.IsInRole("Admin"))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức ănng này" };
                return result;
            }
            if(!Utilities.IsValidEmail(input.Email))
            {
                result.Errors = new string[] { "Định dạng email không hợp lệ" };
                return result;
            }
            if(!Utilities.IsValidPhoneNumber(input.PhoneNumber))
            {
                result.Errors = new string[] { "Định dạng số điẹn thoại không hợp lệ" };
                return result;
            }
            try
            {
                Contact contact = new Contact
                {
                    Address = input.Email,
                    ContactText = input.ContactText,
                    Email = input.Email,
                    Hotline = input.Hotline,
                    PhoneNumber = input.PhoneNumber,
                };
                contact = await _contactRepository.CreateAsync(contact);
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
