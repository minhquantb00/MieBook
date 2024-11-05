using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.BookReview_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.BookReview_UseCase.GetBookReviewById
{
    public class GetBookReviewByIdUseCase : IUseCaseGetById<long, GetBookReviewByIdUseCaseOutput>
    {
        private readonly IRepository<BookReview> _bookReviewRepository;
        private readonly BookReviewConverter _bookConverter;
        public GetBookReviewByIdUseCase(IRepository<BookReview> bookReviewRepository, BookReviewConverter bookConverter)
        {
            _bookReviewRepository = bookReviewRepository;
            _bookConverter = bookConverter;
        }
        public async Task<GetBookReviewByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetBookReviewByIdUseCaseOutput result = new GetBookReviewByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _bookReviewRepository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.DataResponseBookReview = _bookConverter.EntityToDTO(query);
            result.Succeeded = true;
            return result;
        }
    }
}
