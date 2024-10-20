using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Voucher_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.GetVoucherById
{
    public class GetVoucherByIdUseCase : IUseCaseGetById<long, GetVoucherByIdUseCaseOutput>
    {
        private readonly IRepository<Voucher> _voucherRepository;
        private readonly VoucherConverter _voucherConverter;
        public GetVoucherByIdUseCase(IRepository<Voucher> voucherRepository, VoucherConverter voucherConverter)
        {
            _voucherRepository = voucherRepository;
            _voucherConverter = voucherConverter;
        }

        public async Task<GetVoucherByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetVoucherByIdUseCaseOutput result = new GetVoucherByIdUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _voucherRepository.GetByIdAsync(id);
            if(query == null)
            {
                result.Errors = new string[] { "Không tìm thấy voucher" };
                return result;
            }
            result.DataResponseVoucher = _voucherConverter.EntityToDTO(query);
            result.Succeeded = true;
            return result;
        }
    }
}
