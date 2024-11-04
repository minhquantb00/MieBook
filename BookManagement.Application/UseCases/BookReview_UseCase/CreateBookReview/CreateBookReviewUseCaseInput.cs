using BookManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.BookReview_UseCase.CreateBookReview
{
    public class CreateBookReviewUseCaseInput
    {
        public long BookId { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? ImageUrl { get; set; }
        public int NumberOfStars { get; set; }
    }
}
