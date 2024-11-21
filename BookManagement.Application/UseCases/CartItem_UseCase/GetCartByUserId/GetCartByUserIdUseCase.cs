﻿using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Cart_UseCase.GetCartById;
using BookManagement.Application.UseCases.CartItem_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.CartItem_UseCase.GetCartByUserId
{
    public class GetCartByUserIdUseCase : IUseCaseGetById<long, GetCartByUserIdUseCaseOutput>
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly CartItemConverter _cartItemConverter;
        private readonly IRepository<Bill> _billRepository;
        public GetCartByUserIdUseCase(IRepository<Cart> repository, IRepository<User> userRepository, IRepository<CartItem> cartItemRepository, CartItemConverter cartItemConverter, IRepository<Bill> billRepository)
        {
            _cartRepository = repository;
            _userRepository = userRepository;
            _cartItemRepository = cartItemRepository;
            _cartItemConverter = cartItemConverter;
            _billRepository = billRepository;
        }
        public async Task<GetCartByUserIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetCartByUserIdUseCaseOutput result = new GetCartByUserIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _cartRepository.GetAsync(x => x.UserId == id);
            if (query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            var bills = _billRepository.GetAllAsync(x => x.BillStatus == Commons.Enums.Enumerate.BillStatus.DaThanhToan).Result;
            result.DataResponseCart = new Cart_UseCase.MapperGlobal.DataResponseCart
            {
                FullName = _userRepository.GetByIdAsync(query.UserId).Result.FullName,
                Id = query.Id,
                Quantity = _cartItemRepository.GetAllAsync(item => item.CartId == query.Id).Result.Count(),
                TotalPrice = (decimal)_cartItemRepository.GetAllAsync(item => item.CartId == query.Id).Result.Sum(x => x.UnitPrice),
                DataResponseCartItems = _cartItemRepository.GetAllAsync(item => item.CartId == query.Id).Result.Select(item => _cartItemConverter.EntityToDTO(item)),
                NumberOfCustomerBought = bills.Select(item => item.UserId).ToHashSet().Count(),
                StatisticOfMonth = bills.Where(item => item.CreateTime.Month == DateTime.Now.Month).Sum(x => x.TotalPriceAfterDiscount)
            };
            result.Succeeded = true;
            return result;
        }
    }
}
