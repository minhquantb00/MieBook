using BookManagement.Application.Handle.Media;
using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.UpdateDiscountEvent;
using BookManagement.Commons.Enums;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.UpdateBook
{
    public class UpdateBookUseCase : IUseCase<UpdateBookUseCaseInput, UpdateBookUseCaseOutput>
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateBookUseCase(IRepository<Book> bookRepository, IRepository<TopicBook> topicBookRepository, IRepository<Category> categoryRepository, IHttpContextAccessor contextAccessor)
        {
            _bookRepository = bookRepository;
            _topicBookRepository = topicBookRepository;
            _categoryRepository = categoryRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<UpdateBookUseCaseOutput> ExcuteAsync(UpdateBookUseCaseInput input)
        {
            UpdateBookUseCaseOutput result = new UpdateBookUseCaseOutput
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
                var book = await _bookRepository.GetByIdAsync(input.Id);
                if (book == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                book.ManufactureDate = input.ManufactureDate.HasValue ? input.ManufactureDate.Value : book.ManufactureDate;
                book.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : book.Name;
                book.NumberOfPages = input.NumberOfPages.HasValue ? input.NumberOfPages.Value : book.NumberOfPages;
                book.Description = !string.IsNullOrEmpty(input.Description) ? input.Description : book.Description;
                book.Price = input.Price.HasValue ? input.Price.Value : book.Price;
                book.ImageUrl = await HandleUploadImage.Upfile(input.ImageUrl);
                book.CategoryId = input.CategoryId;
                book.TopicBookId = input.TopicBookId;
                book.Author = input.Author;
                book.Quantity = input.Quantity.HasValue ? input.Quantity.Value : book.Quantity;
               
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
