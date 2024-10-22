using BookManagement.Application.OuputBase;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.MapperGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethod
{
    public class GetShippingMethodUseCaseOutput : UseCaseOutputBase
    {
        public IQueryable<DataResponseShippingMethod> DataResponseShippingMethods { get; set; }
    }
}
