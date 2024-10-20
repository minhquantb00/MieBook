using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.MapperGlobal
{
    public class VoucherConverter
    {
        public DataResponseVoucher EntityToDTO(Voucher voucher)
        {
            return new DataResponseVoucher
            {
                Code = voucher.Code,
                CreateTime = voucher.CreateTime,
                DiscountPercent = voucher.DiscountPercent,
                Id = voucher.Id,
                Name = voucher.Name,
            };
        }
    }
}
