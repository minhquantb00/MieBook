using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.CreateEventBook
{
    public class CreateEventBookUseCaseInput
    {
        public long BookId { get; set; }
        public long DiscountEventId { get; set; }
    }
}
