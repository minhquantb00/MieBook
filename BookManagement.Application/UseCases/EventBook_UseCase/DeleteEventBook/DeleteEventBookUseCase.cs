using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.DeleteRole;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.DeleteEventBook
{
    public class DeleteEventBookUseCase : IUseCase<DeleteEventBookUseCaseInput, DeleteEventBookUseCaseOutput>
    {
        private readonly IRepository<EventBook> _eventBookRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteEventBookUseCase(IRepository<EventBook> eventBookRepository,IHttpContextAccessor contextAccessor)
        {
            _eventBookRepository = eventBookRepository;
            _contextAccessor = contextAccessor;
        }
        public async Task<DeleteEventBookUseCaseOutput> ExcuteAsync(DeleteEventBookUseCaseInput input)
        {
            DeleteEventBookUseCaseOutput result = new DeleteEventBookUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            if (!currentUser.IsInRole("Admin"))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            try
            {
                var eventBook = await _eventBookRepository.GetByIdAsync(input.Id);
                if (eventBook == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                await _eventBookRepository.DeleteAsync(eventBook.Id);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<DeleteEventBookUseCaseOutput> ExcuteAsync(long? id, DeleteEventBookUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
