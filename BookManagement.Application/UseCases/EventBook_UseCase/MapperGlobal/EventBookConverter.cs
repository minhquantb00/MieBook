using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.MapperGlobal
{
    public class EventBookConverter
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        public EventBookConverter(IRepository<Book> bookRepository, IRepository<DiscountEvent> discountEventRepository)
        {
            _bookRepository = bookRepository;
            _discountEventRepository = discountEventRepository;
        }
        public DataResponseEventBook EntityToDTO(EventBook eventBook)
        {
            return new DataResponseEventBook
            {
                BookName = _bookRepository.GetByIdAsync(eventBook.BookId).Result.Name,
                DiscountEventName = _discountEventRepository.GetByIdAsync(eventBook.DiscountEventId).Result.EventName
            };
        }
    }
}
