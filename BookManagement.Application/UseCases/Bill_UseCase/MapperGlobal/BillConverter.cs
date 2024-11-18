using BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.User_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Bill_UseCase.MapperGlobal
{
    public class BillConverter
    {
        private readonly IRepository<AddressUser> _addressUserRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        private readonly IRepository<PaymentMethod> _paymentMethodRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly BookConverter _bookConverter;
        private readonly AddressUserConverter _addressUserConverter;
        private readonly UserConverter _userConverter;
        private readonly IRepository<BillDetail> _billDetailRepository;
        public BillConverter(IRepository<AddressUser> addressUserRepository, IRepository<User> userRepository, IRepository<ShippingMethod> shippingMethodRepository, IRepository<PaymentMethod> paymentMethodRepository, AddressUserConverter addressUserConverter, UserConverter userConverter, IRepository<BillDetail> billDetailRepository, IRepository<Book> bookRepository, BookConverter bookConverter)
        {
            _addressUserRepository = addressUserRepository;
            _userRepository = userRepository;
            _shippingMethodRepository = shippingMethodRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _addressUserConverter = addressUserConverter;
            _userConverter = userConverter;
            _billDetailRepository = billDetailRepository;
            _bookRepository = bookRepository;
            _bookConverter = bookConverter;
        }
        public DataResponseBill EntityToDTO(Bill entity)
        {
            return new DataResponseBill()
            {
                DataResponseAddressUser = _addressUserConverter.EntityToDTO(_addressUserRepository.GetByIdAsync(entity.AddressUserId).Result),
                TotalPriceAfterDiscount = entity.TotalPriceAfterDiscount,
                BillStatus = entity.BillStatus.ToString(),
                CreateTime = entity.CreateTime,
                DataResponseUser = _userConverter.EntityToDTO(_userRepository.GetByIdAsync(entity.UserId).Result),
                Id = entity.Id,
                Note = entity.Note,
                PaymentMethodName = _paymentMethodRepository.GetByIdAsync(entity.PaymentMethodId).Result.Name,
                PayTime = entity.PayTime,
                ShippingFee = entity.ShippingFee,
                ShippingMethodName = _shippingMethodRepository.GetByIdAsync(entity.ShippingMethodId).Result.Name,
                TotalPriceBeforeDiscount = entity.TotalPriceBeforeDiscount,
                TradingCode = entity.TradingCode,
                DataResponseBillDetails = _billDetailRepository.GetAllAsync(item => item.BillId == entity.Id).Result.Select(item => new DataResponseBillDetail
                {
                    DataResponseBook = _bookConverter.EntityToDTO(_bookRepository.GetByIdAsync(item.BookId).Result),
                    Id = item.Id,
                    Note = item.Note,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                })
            };
        }
    }
}
