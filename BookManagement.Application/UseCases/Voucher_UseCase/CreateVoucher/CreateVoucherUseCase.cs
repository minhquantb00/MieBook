using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.CreateVoucher
{
    public class CreateVoucherUseCase : IUseCase<CreateVoucherUseCaseInput, CreateVoucherUseCaseOutput>
    {
        private readonly IRepository<Voucher> _voucherRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateVoucherUseCase(IRepository<Voucher> voucherRepository, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _voucherRepository = voucherRepository;
        }
        public async Task<CreateVoucherUseCaseOutput> ExcuteAsync(CreateVoucherUseCaseInput input)
        {
            CreateVoucherUseCaseOutput result = new CreateVoucherUseCaseOutput
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
                Voucher voucher = new Voucher
                {
                    Code = "Mie_" + new Random().Next(1000, 9999).ToString(),
                    CreateTime = DateTime.Now,
                    DiscountPercent = input.DiscountPercent,
                    Name = input.Name,
                };
                voucher = await _voucherRepository.CreateAsync(voucher);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<CreateVoucherUseCaseOutput> ExcuteAsync(long? id, CreateVoucherUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
