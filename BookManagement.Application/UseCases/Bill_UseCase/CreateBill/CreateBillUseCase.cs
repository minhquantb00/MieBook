using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Bill_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Bill_UseCase.CreateBill
{
    public class CreateBillUseCase : IUseCase<CreateBillUseCaseInput, CreateBillUseCaseOutput>
    {
        private readonly IRepository<Bill> _billRepository;
        private readonly IRepository<AddressUser> _addressUserRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        private readonly IRepository<PaymentMethod> _paymentMethodRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BillDetail> _billDetailRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IRepository<UserVoucher> _userVoucherRepository;
        private readonly IRepository<Voucher> _voucherRepository;
        private readonly BillConverter _billConverter;
        public CreateBillUseCase(IRepository<Bill> billRepository, IRepository<AddressUser> addressUserRepository, IRepository<User> userRepository, IRepository<ShippingMethod> shippingMethodRepository, IRepository<PaymentMethod> paymentMethodRepository, IRepository<Book> bookRepository, IRepository<BillDetail> billDetailRepository, IHttpContextAccessor contextAccessor, IRepository<UserVoucher> userVoucherRepository, IRepository<Voucher> voucherRepository, BillConverter billConverter)
        {
            _billDetailRepository = billDetailRepository;
            _addressUserRepository = addressUserRepository;
            _userRepository = userRepository;
            _shippingMethodRepository = shippingMethodRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _bookRepository = bookRepository;
            _billRepository = billRepository;
            _contextAccessor = contextAccessor;
            _userVoucherRepository = userVoucherRepository;
            _voucherRepository = voucherRepository;
            _billConverter = billConverter;
        }
        public async Task<CreateBillUseCaseOutput> ExcuteAsync(CreateBillUseCaseInput input)
        {
            CreateBillUseCaseOutput result = new CreateBillUseCaseOutput
            {
                Succeeded = false,
            };

            var currentUser = _contextAccessor.HttpContext.User;
            string userId = currentUser.FindFirst("Id").Value;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Tài khoản chưa được xác thực" };
                return result;
            }

            var shippingMethod = await _shippingMethodRepository.GetByIdAsync(input.ShippingMethodId);
            if(shippingMethod == null)
            {
                result.Errors = new string[] { "Không tồn tại phương thức giao hàng này" };
                return result;
            }
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(input.PaymentMethodId);
            if(paymentMethod == null)
            {
                result.Errors = new string[] { "Không tồn tại phương pháp thanh toán này" };
                return result;
            }

            try
            {
                Bill bill = new Bill
                {
                    AddressUserId = input.AddressUserId,
                    BillStatus = Commons.Enums.Enumerate.BillStatus.ChuaThanhToan,
                    CreateTime = DateTime.Now,
                    PaymentMethodId = input.PaymentMethodId,    
                    ShippingFee = 25000,
                    ShippingMethodId = input.PaymentMethodId,
                    UserId = long.Parse(userId),
                    TotalPriceAfterDiscount = 0,
                    Note = input.Note,
                    TotalPriceBeforeDiscount = 0,
                    TradingCode = DateTime.Now.Ticks.ToString(),
                    BillDetails = null
                };
                
                bill = await _billRepository.CreateAsync(bill);

                List<BillDetail> billDetails = new List<BillDetail>();
                foreach(var item in input.CreateBillDetailUseCaseInputs)
                {
                    var book = await _bookRepository.GetAsync(i => i.Id == item.BookId);
                    if(book == null)
                    {
                        result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                        return result;
                    }
                    BillDetail billDetail = new BillDetail
                    {
                        BillId = bill.Id,
                        BookId = book.Id,
                        Note = item.Note,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                    };
                    billDetail = await _billDetailRepository.CreateAsync(billDetail);
                    book.Quantity -= billDetail.Quantity;
                    book = await _bookRepository.UpdateAsync(book);
                    billDetails.Add(billDetail);
                }
                bill.BillDetails = billDetails;
                bill = await _billRepository.UpdateAsync(bill);
                var priceGlobal = bill.BillDetails.Sum(x => x.Quantity * x.UnitPrice) + bill.ShippingFee;
                bill.TotalPriceBeforeDiscount = priceGlobal;
                var voucher = await _userVoucherRepository.GetAsync(item => item.Id ==  input.UserVoucherId);
                if(voucher == null || voucher.ExpiredTime < DateTime.Now || voucher.VoucherStatus == Commons.Enums.Enumerate.VoucherStatus.ChuaApDung)
                {
                    bill.TotalPriceAfterDiscount = priceGlobal;
                }
                else
                {
                    var itemVoucher = await _voucherRepository.GetAsync(item => item.Id == voucher.VoucherId);
                    if(itemVoucher == null)
                    {
                        bill.TotalPriceAfterDiscount = priceGlobal;
                    }
                    else
                    {
                        bill.TotalPriceAfterDiscount = priceGlobal - (priceGlobal * itemVoucher.DiscountPercent);
                    }
                }
                
                bill = await _billRepository.UpdateAsync(bill);

                result.Succeeded = true;
                result.DataResponseBill = _billConverter.EntityToDTO(bill);
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
