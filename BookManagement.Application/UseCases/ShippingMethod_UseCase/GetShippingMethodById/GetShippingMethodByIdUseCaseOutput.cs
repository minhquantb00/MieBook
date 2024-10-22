using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethodById
{
    public class GetShippingMethodByIdUseCaseOutput : UseCaseOutputBase
    {
        public DataResponseShippingMethod DataResponseShippingMethod { get; set; }
    }
}
