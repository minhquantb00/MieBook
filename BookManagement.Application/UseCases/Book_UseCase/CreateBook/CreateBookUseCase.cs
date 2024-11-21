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

namespace BookManagement.Application.UseCases.Book_UseCase.CreateBook
{
    public class CreateBookUseCase : IUseCase<CreateBookUseCaseInput, CreateBookUseCaseOutput>
    {
        private readonly IRepository<Book> _bookRepsitory;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<TopicBook> _topicBookRepsitory;
        private readonly IRepository<Category> _categoryRepository; 
        public CreateBookUseCase(IRepository<Book> bookRepsitory, IHttpContextAccessor contextAccessor, IRepository<TopicBook> topicBookRepsitory, IRepository<Category> categoryRepository)
        {
            _bookRepsitory = bookRepsitory;
            _contextAccessor = contextAccessor;
            _topicBookRepsitory = topicBookRepsitory;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateBookUseCaseOutput> ExcuteAsync(CreateBookUseCaseInput input)
        {
            CreateBookUseCaseOutput result = new CreateBookUseCaseOutput
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
                var category = await _categoryRepository.GetAsync(x => x.Id == input.CategoryId);
                if(category == null)
                {
                    result.Errors = new string[] { "Danh mục không tồn tại" };
                    return result;
                }
                var topicBook = await _topicBookRepsitory.GetAsync(x=> x.Id == input.TopicBookId);
                if(topicBook == null)
                {
                    result.Errors = new string[] { "Chủ đề không tồn tại" };
                    return result;
                }
                Book book = new Book
                {
                    Author = input.Author,
                    AverageRating = 0,
                    PriceAfterDiscount = input.Price,
                    CategoryId = input.CategoryId,
                    Code = "MieShop",
                    CollectionId = input.CollectionId,
                    CreateTime = DateTime.Now,
                    Description = input.Description,
                    ImageUrl = await HandleUploadImage.Upfile(input.ImageUrl),
                    InventoryNumber = 0,
                    ManufactureDate = input.ManufactureDate,
                    Name = input.Name,
                    NumberOfPages = input.NumberOfPages,
                    Price = input.Price,
                    TopicBookId = input.TopicBookId,
                    SoldQuantity = 0,
                    Status = Commons.Enums.Enumerate.BookStatus.DangBan,
                    Quantity = input.Quantity,
                };
                book = await _bookRepsitory.CreateAsync(book);
                

                book.Status = book.Quantity > 0 ? Commons.Enums.Enumerate.BookStatus.DangBan : Commons.Enums.Enumerate.BookStatus.HetHang;
                book = await _bookRepsitory.UpdateAsync(book);

                category.NumberOfProducts = _bookRepsitory.GetAllAsync(record => record.Id == book.Id).Result.Count();
                category = await _categoryRepository.UpdateAsync(category);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

    }
}
