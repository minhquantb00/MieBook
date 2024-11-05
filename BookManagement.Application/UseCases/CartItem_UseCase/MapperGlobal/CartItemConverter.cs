using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.MapperGlobal
{
    public class CartItemConverter
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter _converter;
        public CartItemConverter(IRepository<Book> bookRepository, BookConverter converter)
        {
            _bookRepository = bookRepository;
            _converter = converter;
        }
        public DataResponseCartItem EntityToDTO(CartItem cartItem)
        {
            return new DataResponseCartItem
            {
                Id = cartItem.Id,
                Quantity = cartItem.Quantity,
                UnitPrice = cartItem.UnitPrice,
                DataResponseBook = _converter.EntityToDTO(_bookRepository.GetByIdAsync(cartItem.BookId).Result),
            };
        }
    }
}
