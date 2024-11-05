using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.BookReview_UseCase.GetBookReviewById;
using BookManagement.Application.UseCases.CartItem_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.GetCartItemById
{
    public class GetCartItemByIdUseCase : IUseCaseGetById<long, GetCartItemByIdUseCaseOutput>
    {
        private readonly IRepository<CartItem> _repository;
        private readonly CartItemConverter _cartItemConverter;
        public GetCartItemByIdUseCase(IRepository<CartItem> repository, CartItemConverter cartItemConverter)
        {
            _repository = repository;
            _cartItemConverter = cartItemConverter;
        }

        public async Task<GetCartItemByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetCartItemByIdUseCaseOutput result = new GetCartItemByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _repository.GetByIdAsync(id);
            if (query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.DataResponseCartItem = _cartItemConverter.EntityToDTO(query);
            result.Succeeded = true;
            return result;
        }
    }
}
