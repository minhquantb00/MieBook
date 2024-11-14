﻿using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.Book_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.Book_UseCase.GetBook
{
    public class GetBookUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseBook> DataResponseBooks { get; set; }
    }
}