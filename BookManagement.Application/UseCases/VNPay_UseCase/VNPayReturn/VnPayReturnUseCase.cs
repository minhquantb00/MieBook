using BookManagement.Application.IUseCases;
using BookManagement.Commons.HandleEmail;
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

namespace BookManagement.Application.UseCases.VNPay_UseCase.VNPayReturn
{
    public class VnPayReturnUseCase : IUseCase<VnPayReturnUseCaseInput, VnPayReturnUseCaseOutput>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Bill> _billRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IRepository<BillDetail> _billDetailRepository;
        public VnPayReturnUseCase(IRepository<User> userRepository, IRepository<Bill> billRepository, IHttpContextAccessor contextAccessor, IConfiguration configuration, IRepository<BillDetail> billDetailRepository)
        {
            _billDetailRepository = billDetailRepository;
            _billRepository = billRepository;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public async Task<VnPayReturnUseCaseOutput> ExcuteAsync(VnPayReturnUseCaseInput input)
        {
            VnPayReturnUseCaseOutput result = new VnPayReturnUseCaseOutput
            {
                Succeeded = false,
            };
            string vnp_TmnCode = _configuration.GetSection("VnPay:vnp_TmnCode").Value;
            string vnp_HashSecret = _configuration.GetSection("VnPay:vnp_HashSecret").Value;

            VNPayLibrary vnPayLibrary = new VNPayLibrary();
            foreach (var (key, value) in input.vnpayData)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnPayLibrary.AddResponseData(key, value);
                }
            }

            string hoaDonId = vnPayLibrary.GetResponseData("vnp_TxnRef");
            string vnp_ResponseCode = vnPayLibrary.GetResponseData("vnp_ResponseCode");
            string vnp_TransactionStatus = vnPayLibrary.GetResponseData("vnp_TransactionStatus");
            string vnp_SecureHash = vnPayLibrary.GetResponseData("vnp_SecureHash");
            double vnp_Amount = Convert.ToDouble(vnPayLibrary.GetResponseData("vnp_Amount"));
            bool check = vnPayLibrary.ValidateSignature(vnp_SecureHash, vnp_HashSecret);

            if (check)
            {
                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                {
                    var bill = await _billRepository.GetByIdAsync(long.Parse(hoaDonId));

                    if (bill == null)
                    {
                        result.Errors = new string[] { "Không tìm thấy hóa đơn" };
                        return result;
                    }

                    bill.BillStatus = Commons.Enums.Enumerate.BillStatus.DaThanhToan;
                    bill.PayTime = DateTime.Now;
                    bill = await _billRepository.UpdateAsync(bill);

                    var user = await _userRepository.GetAsync(item => item.Id == bill.UserId);
                    if (user != null)
                    {
                        string email = user.Email;
                        string mss = HandleSendEmail.SendEmail(new EmailTo
                        {
                            To = email,
                            Subject = $"Thanh Toán đơn hàng: {bill.Id}",
                            Content = "Bạn đã mua sản phẩm thành công! Xin chân thành cảm ơn"
                        });
                    }
                    result.Succeeded = true;
                    result.ResultString = "Giao dịch thành công đơn hàng " + bill.Id;
                    return result;
                }
                else
                {
                    result.Errors = new string[] { $"Lỗi trong khi thực hiện giao dịch. Mã lỗi: {vnp_ResponseCode}" };
                    return result;
                }
            }
            else
            {
                result.Errors = new string[] { "Có lỗi trong quá trình xử lý" };
                return result;
            }
        }
    }
}
