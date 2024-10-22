using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.UpdateRole;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.UpdateEventBook
{
    public class UpdateEventBookUseCase : IUseCase<UpdateEventBookUseCaseInput, UpdateEventBookUseCaseOutput>
    {
        private readonly IRepository<EventBook> _eventBookRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateEventBookUseCase(IRepository<EventBook> eventBookRepository, IRepository<Book> bookRepository, IHttpContextAccessor contextAccessor, IRepository<DiscountEvent> discountEventRepository)
        {
            _bookRepository = bookRepository;
            _eventBookRepository = eventBookRepository;
            _contextAccessor = contextAccessor;
            _discountEventRepository = discountEventRepository;
        }
        public async Task<UpdateEventBookUseCaseOutput> ExcuteAsync(UpdateEventBookUseCaseInput input)
        {
            UpdateEventBookUseCaseOutput result = new UpdateEventBookUseCaseOutput
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
                var book = await _bookRepository.GetByIdAsync((int)input.BookId);
                if (input.BookId.HasValue)
                {
                    if(book == null)
                    {
                        result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                        return result;
                    }
                }
                var discountEvent = await _discountEventRepository.GetByIdAsync((int) input.DiscountEventId);
                if (input.DiscountEventId.HasValue)
                {
                    if (discountEvent == null)
                    {
                        result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                        return result;
                    }
                }
                eventBook.BookId = book != null ?(long) input.BookId : eventBook.BookId;
                eventBook.DiscountEventId = discountEvent != null ? (long)input.DiscountEventId : eventBook.DiscountEventId;
                eventBook = await _eventBookRepository.UpdateAsync(eventBook);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<UpdateEventBookUseCaseOutput> ExcuteAsync(long? id, UpdateEventBookUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
