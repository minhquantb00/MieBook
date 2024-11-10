using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.CreateRole;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.CreateEventBook
{
    public class CreateEventBookUseCase : IUseCase<CreateEventBookUseCaseInput, CreateEventBookUseCaseOutput>
    {
        private readonly IRepository<EventBook> _eventBookRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateEventBookUseCase(IRepository<EventBook> eventBookRepository, IRepository<Book> bookRepository, IHttpContextAccessor contextAccessor, IRepository<DiscountEvent> discountEventRepository)
        {
            _bookRepository = bookRepository;
            _eventBookRepository = eventBookRepository;
            _contextAccessor = contextAccessor;
            _discountEventRepository = discountEventRepository;
        }
        public async Task<CreateEventBookUseCaseOutput> ExcuteAsync(CreateEventBookUseCaseInput input)
        {
            CreateEventBookUseCaseOutput result = new CreateEventBookUseCaseOutput
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
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            try
            {
                var book = await _bookRepository.GetByIdAsync(input.BookId);
                if (book == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                var discountEvent = await _discountEventRepository.GetByIdAsync(input.DiscountEventId);
                if(discountEvent == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                EventBook eventBook = new EventBook
                {
                    BookId = input.BookId,
                    DiscountEventId = input.DiscountEventId,
                };
                eventBook = await _eventBookRepository.CreateAsync(eventBook);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
