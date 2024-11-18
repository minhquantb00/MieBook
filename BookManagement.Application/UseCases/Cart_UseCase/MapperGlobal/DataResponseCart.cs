using BookManagement.Application.UseCases.CartItem_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Cart_UseCase.MapperGlobal
{
    public class DataResponseCart
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public IQueryable<DataResponseCartItem> DataResponseCartItems { get; set; }
    }
}
