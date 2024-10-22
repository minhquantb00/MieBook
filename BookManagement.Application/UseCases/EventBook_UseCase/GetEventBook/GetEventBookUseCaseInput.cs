using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.GetEventBook
{
    public class GetEventBookUseCaseInput
    {
        public long? BookId { get; set; }
        public long? DiscountEventId { get; set; }
    }
}
