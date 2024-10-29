using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.DeleteBook
{
    public class DeleteBookUseCase : IUseCase<DeleteBookUseCaseInput, DeleteBookUseCaseOutput>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteBookUseCase(IRepository<Book> bookRepository, IHttpContextAccessor contextAccessor)
        {
            _bookRepository = bookRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<DeleteBookUseCaseOutput> ExcuteAsync(DeleteBookUseCaseInput input)
        {
            DeleteBookUseCaseOutput result = new DeleteBookUseCaseOutput
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
                var book = await _bookRepository.GetByIdAsync(input.Id);
                if (book == null)
                {
                    result.Errors = new string[] { "Không tìm thấy contact" };
                    return result;
                }
                await _bookRepository.DeleteAsync(book.Id);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<DeleteBookUseCaseOutput> ExcuteAsync(long? id, DeleteBookUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
