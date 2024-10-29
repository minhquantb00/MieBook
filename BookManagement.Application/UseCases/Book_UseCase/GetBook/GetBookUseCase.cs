using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Contact_UseCase.GetContact;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.GetBook
{
    public class GetBookUseCase : IUseCase<GetBookUseCaseInput, GetBookUseCaseOutput>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly BookConverter _converter;
        public GetBookUseCase(IRepository<Book> bookRepository, IRepository<TopicBook> topicBookRepository, IRepository<Category> categoryRepository, BookConverter converter)
        {
            _bookRepository = bookRepository;
            _topicBookRepository = topicBookRepository;
            _categoryRepository = categoryRepository;
            _converter = converter;
        }

        public async Task<GetBookUseCaseOutput> ExcuteAsync(GetBookUseCaseInput input)
        {
            GetBookUseCaseOutput result = new GetBookUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _bookRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(input.Keyword))
            {
                query = query.AsNoTracking().Where(record => record.Name.Contains(input.Keyword) || record.Author.Contains(input.Keyword));
            }
            if (input.CategoryId.HasValue)
            {
                query = query.AsNoTracking().Where(record => record.CategoryId == input.CategoryId);
            }
            if(input.TopicBookId.HasValue)
            {
                query = query.AsNoTracking().Where(record => record.TopicBookId == input.TopicBookId);
            }
            if (input.PriceFrom.HasValue && !input.PriceTo.HasValue)
            {
                query = query.AsNoTracking().Where(x => x.PriceAfterDiscount >= input.PriceFrom);
            }
            if (input.PriceFrom.HasValue && input.PriceTo.HasValue)
            {
                query = query.AsNoTracking().Where(x => x.PriceAfterDiscount >= input.PriceFrom && x.PriceAfterDiscount <= input.PriceTo);
            }
            result.DataResponseBooks = query.AsNoTracking().Select(item => _converter.EntityToDTO(item));
            result.Succeeded = true;
            return result;
        }

        public Task<GetBookUseCaseOutput> ExcuteAsync(long? id, GetBookUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
