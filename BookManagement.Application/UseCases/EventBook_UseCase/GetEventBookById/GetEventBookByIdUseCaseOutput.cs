using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.EventBook_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.GetEventBookById
{
    public class GetEventBookByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseEventBook DataResponseEventBook { get; set; }
    }
}
