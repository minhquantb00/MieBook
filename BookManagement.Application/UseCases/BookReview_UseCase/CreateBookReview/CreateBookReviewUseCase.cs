using BookManagement.Application.Handle.Media;
using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.BookReview_UseCase.CreateBookReview
{
    public class CreateBookReviewUseCase : IUseCase<CreateBookReviewUseCaseInput, CreateBookReviewUseCaseOutput>
    {
        private readonly IRepository<BookReview> _bookReviewRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<Book> _bookRepository;
        public CreateBookReviewUseCase(IRepository<BookReview> bookReviewRepository, IHttpContextAccessor contextAccessor, IRepository<Book> bookRepository)
        {
            _bookReviewRepository = bookReviewRepository;
            _contextAccessor = contextAccessor;
            _bookRepository = bookRepository;
        }

        public async Task<CreateBookReviewUseCaseOutput> ExcuteAsync(CreateBookReviewUseCaseInput input)
        {
            CreateBookReviewUseCaseOutput result = new CreateBookReviewUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            string userId = currentUser.FindFirst("Id").Value;
            var book = await _bookRepository.GetByIdAsync(input.BookId);
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] {"Người dùng chưa được xác thực" };
                return result;
            }
            if(book == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            try
            {
                BookReview bookReview = new BookReview
                {
                    BookId = input.BookId,
                    Content = input.Content,
                    ImageUrl = input.ImageUrl != null ? await HandleUploadImage.Upfile(input.ImageUrl) : "",
                    NumberOfStars = input.NumberOfStars,
                    ReviewTime = DateTime.Now,
                    UserId = long.Parse(userId),
                };
                bookReview = await _bookReviewRepository.CreateAsync(bookReview);

                var numberOfReview = _bookReviewRepository.GetAllAsync(record => record.BookId == bookReview.BookId).Result.Select(item => item.Id).Count();
                var sumStart = _bookReviewRepository.GetAllAsync(_record => _record.BookId == bookReview.BookId).Result.Sum(item => item.NumberOfStars);
                book.AverageRating = (int) sumStart / numberOfReview;

                book = await _bookRepository.UpdateAsync(book);
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
