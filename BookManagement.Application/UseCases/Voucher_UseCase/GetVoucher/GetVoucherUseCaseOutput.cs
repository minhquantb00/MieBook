using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Voucher_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.GetVoucher
{
    public class GetVoucherUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseVoucher> DataResponseVouchers { get; set; }
    }
}
