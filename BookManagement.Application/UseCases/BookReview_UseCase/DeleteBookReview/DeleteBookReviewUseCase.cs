using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.DeleteBook;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.BookReview_UseCase.DeleteBookReview
{
    public class DeleteBookReviewUseCase : IUseCase<DeleteBookReviewUseCaseInput, DeleteBookReviewUseCaseOutput>
    {
        private readonly IRepository<BookReview> _bookReviewRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteBookReviewUseCase(IRepository<BookReview> bookReviewRepository, IHttpContextAccessor contextAccessor)
        {
            _bookReviewRepository = bookReviewRepository;
            _contextAccessor = contextAccessor;
        }
        public async Task<DeleteBookReviewUseCaseOutput> ExcuteAsync(DeleteBookReviewUseCaseInput input)
        {
            DeleteBookReviewUseCaseOutput result = new DeleteBookReviewUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            string userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            
            try
            {
                var bookReview = await _bookReviewRepository.GetByIdAsync(input.Id);
                if (bookReview == null)
                {
                    result.Errors = new string[] { "Không tìm thấy contact" };
                    return result;
                }
                if (long.Parse(userId) != bookReview.UserId)
                {
                    result.Errors = new string[] { "Bạn không có quyền thực hiện chức ănng này" };
                    return result;
                }
                await _bookReviewRepository.DeleteAsync(bookReview.Id);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<DeleteBookReviewUseCaseOutput> ExcuteAsync(long? id, DeleteBookReviewUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
