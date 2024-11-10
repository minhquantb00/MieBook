using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.CreateCartItem
{
    public class CreateCartItemUseCase : IUseCase<CreateCartItemUseCaseInput, CreateCartItemUseCaseOutput>
    {
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Book> _bookRepository;
        public CreateCartItemUseCase(IRepository<CartItem> cartItemRepository, IRepository<Cart> cartRepository, IRepository<Book> bookRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _bookRepository = bookRepository;
        }

        public async Task<CreateCartItemUseCaseOutput> ExcuteAsync(CreateCartItemUseCaseInput input)
        {
            CreateCartItemUseCaseOutput result = new CreateCartItemUseCaseOutput
            {
                Succeeded = false,
            };
            var cart = await _cartRepository.GetByIdAsync(input.CartId);
            if (cart == null)
            {
                result.Errors = new string[] { "Giỏ hàng không tồn tại" };
                return result;
            }
            var book = await _bookRepository.GetByIdAsync(input.BookId);
            if(book == null)
            {
                result.Errors = new string[] { "Thông tin sách không tồn tại" };
                return result;
            }

            try
            {
                CartItem cartItem = new CartItem
                {
                    BookId = input.BookId,
                    CartId = input.CartId,
                    CreateTime = DateTime.Now,
                    Quantity = 1,
                    UnitPrice = book.PriceAfterDiscount
                };
                cartItem = await _cartItemRepository.CreateAsync(cartItem);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
