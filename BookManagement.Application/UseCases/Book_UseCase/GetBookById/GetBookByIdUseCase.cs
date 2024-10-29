using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEventById;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.GetBookById
{
    public class GetBookByIdUseCase : IUseCaseGetById<long, GetBookByIdUseCaseOutput>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter _converter;
        public GetBookByIdUseCase(IRepository<Book> bookRepository, BookConverter converter)
        {
            _bookRepository = bookRepository;
            _converter = converter;
        }

        public async Task<GetBookByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetBookByIdUseCaseOutput result = new GetBookByIdUseCaseOutput
            {
                Succeeded = false
            };

            var query = await _bookRepository.GetByIdAsync(id);
            if (query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.DataResponseBook = _converter.EntityToDTO(query);
            result.Succeeded = true;
            return result;
        }
    }
}
