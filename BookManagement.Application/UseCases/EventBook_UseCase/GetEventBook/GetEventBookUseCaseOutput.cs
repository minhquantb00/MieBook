using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.EventBook_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.EventBook_UseCase.GetEventBook
{
    public class GetEventBookUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseEventBook> DataResponseEventBooks { get; set; }
    }
}
