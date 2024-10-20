using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Voucher_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.GetVoucher
{
    public class GetVoucherUseCase : IUseCase<GetVoucherUseCaseInput, GetVoucherUseCaseOutput>
    {
        private readonly IRepository<Voucher> _voucherRepository;
        private readonly VoucherConverter _voucherConverter;
        public GetVoucherUseCase(IRepository<Voucher> voucherRepository, VoucherConverter voucherConverter)
        {
            _voucherRepository = voucherRepository;
            _voucherConverter = voucherConverter;
        }

        public async Task<GetVoucherUseCaseOutput> ExcuteAsync(GetVoucherUseCaseInput input)
        {
            GetVoucherUseCaseOutput result = new GetVoucherUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _voucherRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.AsNoTracking().Where(record => record.Name.Contains(input.Name));
            }
            result.DataResponseVouchers = query.AsNoTracking().Select(item => _voucherConverter.EntityToDTO(item));
            result.Succeeded = true;
            return result;
        }

        public Task<GetVoucherUseCaseOutput> ExcuteAsync(long? id, GetVoucherUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
