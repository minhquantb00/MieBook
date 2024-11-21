using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.BookReview_UseCase.GetBookReviewById;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Cart_UseCase.GetCartById
{
    public class GetCartByIdUseCase : IUseCaseGetById<long, GetCartByIdUseCaseOutput>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IRepository<Bill> _billRepository;
        public GetCartByIdUseCase(IRepository<Cart> repository, IRepository<User> userRepository, IRepository<CartItem> cartItemRepository, IRepository<Bill> billRepository)
        {
            _cartRepository = repository;
            _userRepository = userRepository;
            _cartItemRepository = cartItemRepository;
            _billRepository = billRepository;
        }
        public async Task<GetCartByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetCartByIdUseCaseOutput result = new GetCartByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _cartRepository.GetByIdAsync(id);
            if (query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            var bills = _billRepository.GetAllAsync().Result;
            result.DataResponseCart = new MapperGlobal.DataResponseCart
            {
                FullName = _userRepository.GetByIdAsync(query.UserId).Result.FullName,
                Id = query.Id,
                Quantity = _cartItemRepository.GetAllAsync(item => item.CartId == query.Id).Result.Count(),
                TotalPrice = (decimal) _cartItemRepository.GetAllAsync(item => item.CartId == query.Id).Result.Sum(x => x.UnitPrice),
                NumberOfCustomerBought = bills.Select(item => item.UserId).ToHashSet().Count()
            };
            result.Succeeded = true;
            return result;
        }
    }
}
