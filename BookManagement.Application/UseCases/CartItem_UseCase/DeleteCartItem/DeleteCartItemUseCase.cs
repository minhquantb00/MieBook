using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.BookReview_UseCase.DeleteBookReview;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.DeleteCartItem
{
    public class DeleteCartItemUseCase : IUseCase<DeleteCartItemUseCaseInput, DeleteCartItemUseCaseOutput>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<CartItem> _cartItemRepository;
        public DeleteCartItemUseCase(IHttpContextAccessor contextAccessor, IRepository<CartItem> cartItemRepository)
        {
            _contextAccessor = contextAccessor;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<DeleteCartItemUseCaseOutput> ExcuteAsync(DeleteCartItemUseCaseInput input)
        {
            DeleteCartItemUseCaseOutput result = new DeleteCartItemUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            string userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }

            try
            {
                var cartItem = await _cartItemRepository.GetByIdAsync(input.Id);
                if (cartItem == null)
                {
                    result.Errors = new string[] { "Không tìm thấy contact" };
                    return result;
                }
                await _cartItemRepository.DeleteAsync(cartItem.Id);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<DeleteCartItemUseCaseOutput> ExcuteAsync(long? id, DeleteCartItemUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
