using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Contact_UseCase.DeleteContact
{
    public class DeleteContactUseCase : IUseCase<DeleteContactUseCaseInput, DeleteContactUseCaseOutput>
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteContactUseCase(IRepository<Contact> contactRepository, IHttpContextAccessor contextAccessor)
        {
            _contactRepository = contactRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<DeleteContactUseCaseOutput> ExcuteAsync(DeleteContactUseCaseInput input)
        {
            DeleteContactUseCaseOutput result = new DeleteContactUseCaseOutput
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
                if (contact == null)
                {
                    result.Errors = new string[] { "Không tìm thấy contact" };
                    return result;
                }
                await _contactRepository.DeleteAsync(contact.Id);
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
