using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Voucher_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.GetVoucherById
{
    public class GetVoucherByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseVoucher DataResponseVoucher { get; set; }
    }
}
