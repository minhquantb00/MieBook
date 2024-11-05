using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.MapperGlobal
{
    public class DataResponseCartItem
    {
        public long Id { get; set; }
        public DataResponseBook DataResponseBook { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
