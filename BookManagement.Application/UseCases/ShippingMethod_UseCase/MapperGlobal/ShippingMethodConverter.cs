using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.MapperGlobal
{
    public class ShippingMethodConverter
    {
        public DataResponseShippingMethod EntityToDTO(ShippingMethod shippingMethod)
        {
            return new DataResponseShippingMethod
            {
                CreateTime = shippingMethod.CreateTime,
                Name = shippingMethod.Name,
                Status = shippingMethod.Status.ToString(),
                UpdateTime = shippingMethod.UpdateTime,
                Id = shippingMethod.Id,
            };
        }
    }
}
