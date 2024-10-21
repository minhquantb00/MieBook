﻿using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Contact_UseCase.UpdateContact
{
    public class UpdateContactUseCase : IUseCase<UpdateContactUseCaseInput, UpdateContactUseCaseOutput>
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateContactUseCase(IRepository<Contact> contactRepository, IHttpContextAccessor contextAccessor)
        {
            _contactRepository = contactRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<UpdateContactUseCaseOutput> ExcuteAsync(UpdateContactUseCaseInput input)
        {
            UpdateContactUseCaseOutput result = new UpdateContactUseCaseOutput
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
            try
            {
                var contact = await _contactRepository.GetByIdAsync(input.Id);
                if(contact == null)
                {
                    result.Errors = new string[] { "Không tìm thấy liên hệ" };
                    return result;
                }
                contact.Address = !string.IsNullOrEmpty(input.Address) ? input.Address : contact.Address;
                contact.PhoneNumber = !string.IsNullOrEmpty(input.PhoneNumber) ? input.PhoneNumber : contact.PhoneNumber;
                contact.Email = !string.IsNullOrEmpty(input.Email) ? input.Email : contact.Email;
                contact.ContactText = !string.IsNullOrEmpty(input.ContactText) ? input.ContactText : contact.ContactText;
                contact.Hotline = !string.IsNullOrEmpty(input.Hotline) ? input.Hotline : contact.Hotline;
                contact = await _contactRepository.UpdateAsync(contact);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<UpdateContactUseCaseOutput> ExcuteAsync(long? id, UpdateContactUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
