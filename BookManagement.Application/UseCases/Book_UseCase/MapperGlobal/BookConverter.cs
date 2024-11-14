﻿using BookManagement.Application.UseCases.BookReview_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Category_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.TopicBook_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.MapperGlobal
{
    public class BookConverter
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<TopicBook> _topicBookRepository;
        private readonly CategoryConverter _categoryConverter;
        private readonly TopicBookConverter _topicBookConverter;
        private readonly IRepository<BookReview> _bookReviewRepository;
        private readonly BookReviewConverter _bookReviewConverter;
        public BookConverter(IRepository<Category> categoryRepository, IRepository<TopicBook> topicBookRepository, CategoryConverter categoryConverter, TopicBookConverter topicBookConverter, IRepository<BookReview> bookReviewRepository, BookReviewConverter bookReviewConverter)
        {
            _categoryRepository = categoryRepository;
            _topicBookRepository = topicBookRepository;
            _categoryConverter = categoryConverter;
            _topicBookConverter = topicBookConverter;
            _bookReviewConverter = bookReviewConverter;
            _bookReviewRepository = bookReviewRepository;
        }
        public DataResponseBook EntityToDTO(Book book)
        {
            return new DataResponseBook
            {
                Author = book.Author,
                AverageRating = book.AverageRating,
                PriceAfterDiscount = book.PriceAfterDiscount,
                CategoryName = book.CategoryId.HasValue ?  _categoryRepository.GetAsync(item => item.Id == book.CategoryId).Result.Name : "",
                Code = book.Code,
                CreateTime = book.CreateTime,
                Description = book.Description,
                Id = book.Id,
                ImageUrl = book.ImageUrl,
                InventoryNumber = book.InventoryNumber,
                ManufactureDate = book.ManufactureDate,
                Name = book.Name,
                NumberOfPages = book.NumberOfPages,
                Price = book.Price,
                SoldQuantity = book.SoldQuantity,
                Status = book.Status == Commons.Enums.Enumerate.BookStatus.HetHang ? "Hết hàng" : "Đang bán",
                TopicBookName = book.TopicBookId.HasValue ? _topicBookRepository.GetAsync(item => item.Id == book.TopicBookId).Result.Name : "",
                UpdateTime = book.UpdateTime,
                Quantity = book.Quantity,
                ReviewQuantity = _bookReviewRepository.GetAllAsync(item => item.BookId == book.Id).Result.Count(),
                DataResponseBookReviews = _bookReviewRepository.GetAllAsync().Result.AsNoTracking().Select(item => _bookReviewConverter.EntityToDTO(item)),
            };
        }
    }
}