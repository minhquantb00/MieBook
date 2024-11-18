using BookManagement.Application.IUseCases;
using BookManagement.Commons.HandleVNPay;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.VNPay_UseCase.CreateUrlPayment
{
    public class CreateUrlPaymentUseCase : IUseCasePayment<CreateUrlPaymentUseCaseInput, CreateUrlPaymentUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Bill> _billRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IRepository<BillDetail> _billDetailRepository;
        public CreateUrlPaymentUseCase(IRepository<User> userRepository, IRepository<Bill> billRepository, IHttpContextAccessor contextAccessor, IConfiguration configuration, IRepository<BillDetail> billDetailRepository)
        {
            _billDetailRepository = billDetailRepository;
            _billRepository = billRepository;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public async Task<CreateUrlPaymentUseCaseOutput> ExcuteAsync(CreateUrlPaymentUseCaseInput input, HttpContext httpContext)
        {
            CreateUrlPaymentUseCaseOutput result = new CreateUrlPaymentUseCaseOutput
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
            var user = await _userRepository.GetByIdAsync(long.Parse(userId));


            var bill = await _billRepository.GetByIdAsync(input.BillId);
            if (user.Id == bill.UserId)
            {
                if (bill.BillStatus == Commons.Enums.Enumerate.BillStatus.DaThanhToan)
                {
                    result.Errors = new string[] { "Hóa đơn đã được thanh toán trước đó" };
                    return result;
                }
                if (bill.BillStatus == Commons.Enums.Enumerate.BillStatus.ChuaThanhToan && bill.TotalPriceAfterDiscount != 0 && bill.TotalPriceAfterDiscount != null)
                {
                    VNPayLibrary pay = new VNPayLibrary();

                    pay.AddRequestData("vnp_Version", "2.1.0");
                    pay.AddRequestData("vnp_Command", "pay");
                    pay.AddRequestData("vnp_TmnCode", "NLWXHLN1");
                    pay.AddRequestData("vnp_Amount", (double.Parse((bill.TotalPriceAfterDiscount * 100).ToString()).ToString()));
                    pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                    pay.AddRequestData("vnp_CurrCode", "VND");
                    pay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(httpContext));
                    pay.AddRequestData("vnp_Locale", "vn");
                    pay.AddRequestData("vnp_OrderInfo", $"Thanh toan don hang {bill.Id}");
                    pay.AddRequestData("vnp_OrderType", "other");
                    pay.AddRequestData("vnp_ReturnUrl", _configuration.GetSection("VnPay:ReturnUrl").Value);
                    pay.AddRequestData("vnp_TxnRef", bill.Id.ToString());

                    string url = pay.CreateRequestUrl(_configuration.GetSection("VnPay:vnp_Url").Value, _configuration.GetSection("VnPay:vnp_HashSecret").Value);
                    result.URL = url;
                    result.Succeeded = true;
                    return result;
                }
                result.Errors = new string[] { "Vui lòng kiểm tra lại hóa đơn" };
                result.Succeeded = false;
                return result;
            }
            result.Errors = new string[] { "Vui lòng kiểm tra lại thông tin người thanh toán" };
            result.Succeeded = false;
            return result;
        }
    }
}
