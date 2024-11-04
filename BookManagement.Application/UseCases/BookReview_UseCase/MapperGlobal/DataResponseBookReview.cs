using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.BookReview_UseCase.MapperGlobal
{
    public class DataResponseBookReview
    {
        public string FullName { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime ReviewTime { get; set; }
    }
}
