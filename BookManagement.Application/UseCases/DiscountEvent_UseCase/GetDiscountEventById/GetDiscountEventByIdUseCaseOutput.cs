using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEventById
{
    public class GetDiscountEventByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseDiscountEvent DataResponseDiscountEvent { get; set; }
    }
}
