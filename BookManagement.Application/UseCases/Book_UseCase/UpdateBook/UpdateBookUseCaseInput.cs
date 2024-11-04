using BookManagement.Commons.Enums;
using BookManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.UpdateBook
{
    public class UpdateBookUseCaseInput
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? ImageUrl { get; set; }
        public string? Author { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public int? NumberOfPages { get; set; }
        public long? CategoryId { get; set; }
        public long? TopicBookId { get; set; }
    }
}
