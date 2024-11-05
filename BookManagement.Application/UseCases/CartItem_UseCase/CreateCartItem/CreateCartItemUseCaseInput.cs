using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.CreateCartItem
{
    public class CreateCartItemUseCaseInput
    {
        public long CartId { get; set; }
        public long BookId { get; set; }
    }
}
