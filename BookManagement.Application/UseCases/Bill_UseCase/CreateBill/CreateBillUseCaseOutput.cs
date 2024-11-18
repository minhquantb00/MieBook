﻿using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Bill_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Bill_UseCase.CreateBill
{
    public class CreateBillUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseBill DataResponseBill { get; set; }
    }
}
