using BookManagement.Commons.Enums;
using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.GetBook
{
    public class GetBookUseCaseInput
    {
        public string? Keyword { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }

        public long? CategoryId { get; set; }
        public long? TopicBookId { get; set; }
    }
}
