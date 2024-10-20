﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Voucher_UseCase.MapperGlobal
{
    public class DataResponseVoucher
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double DiscountPercent { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
