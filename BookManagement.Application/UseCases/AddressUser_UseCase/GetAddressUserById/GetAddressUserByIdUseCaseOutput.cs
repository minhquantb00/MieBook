﻿using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.AddressUser_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.AddressUser_UseCase.GetAddressUserById
{
    public class GetAddressUserByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseAddressUser DataResponseAddressUser { get; set; }
    }
}
