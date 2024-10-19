using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Voucher_UseCase.CreateVoucher;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.UpdateVoucher
{
    public class UpdateVoucherUseCase : IUseCase<UpdateVoucherUseCaseInput, UpdateVoucherUseCaseOutput>
    {
        private readonly IRepository<Voucher> _voucherRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateVoucherUseCase(IRepository<Voucher> voucherRepository, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _voucherRepository = voucherRepository;
        }
        public async Task<UpdateVoucherUseCaseOutput> ExcuteAsync(UpdateVoucherUseCaseInput input)
        {

            UpdateVoucherUseCaseOutput result = new UpdateVoucherUseCaseOutput
            {
                Succeeded = false,
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            if (!currentUser.IsInRole("Admin"))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            try
            {
                var voucher = await _voucherRepository.GetByIdAsync(input.Id);
                if (voucher == null)
                {
                    result.Errors = new string[] { "Voucher không tồn tại" };
                    return result;
                }
                voucher.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : voucher.Name;
                voucher.DiscountPercent = input.DiscountPercent.HasValue ? input.DiscountPercent.Value : voucher.DiscountPercent;
                voucher = await _voucherRepository.UpdateAsync(voucher);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<UpdateVoucherUseCaseOutput> ExcuteAsync(long? id, UpdateVoucherUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
