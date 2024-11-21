using BookManagement.Application.UseCases.BookReview_UseCase.MapperGlobal;
using BookManagement.Commons.Enums;
using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.MapperGlobal
{
    public class DataResponseBook
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int SoldQuantity { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public int? Quantity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int NumberOfPages { get; set; }
        public double PriceAfterDiscount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int AverageRating { get; set; }
        public string Status { get; set; }
        public int InventoryNumber { get; set; }
        public string CategoryName { get; set; }
        public string TopicBookName { get; set; }
        public int ReviewQuantity { get; set; }
        public double PercentOf5Star {  get; set; }
        public double PercentOf4Star { get; set; }
        public double PercentOf3Star { get; set; }
        public double PercentOf2Star { get; set; }
        public double PercentOf1Star { get; set; }
        public int NumberOfCustomerBought {  get; set; }
        public IQueryable<DataResponseBookReview> DataResponseBookReviews { get; set; }
    }
}
