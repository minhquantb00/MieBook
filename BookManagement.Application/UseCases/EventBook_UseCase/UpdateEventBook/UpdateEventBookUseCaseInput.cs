using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.UpdateEventBook
{
    public class UpdateEventBookUseCaseInput
    {
        public long Id { get; set; }
        public long? BookId { get; set; }
        public long? DiscountEventId { get; set; }
    }
}
