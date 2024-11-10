using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.GetRole;
using BookManagement.Application.UseCases.Role_UseCase.MapperGlobal;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethod
{
    public class GetShippingMethodUseCase : IUseCase<GetShippingMethodUseCaseInput, GetShippingMethodUseCaseOutput>
    {
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        private readonly ShippingMethodConverter _shippingMethodConverter;
        public GetShippingMethodUseCase(IRepository<ShippingMethod> shippingMethodRepository, ShippingMethodConverter shippingMethodConverter)
        {
            _shippingMethodConverter = shippingMethodConverter;
            _shippingMethodRepository = shippingMethodRepository;
        }
        public async Task<GetShippingMethodUseCaseOutput> ExcuteAsync(GetShippingMethodUseCaseInput input)
        {
            GetShippingMethodUseCaseOutput result = new GetShippingMethodUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _shippingMethodRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(input.Name))
            {
                query = query.AsNoTracking().Where(record => record.Name.Contains(input.Name));
            }
            result.DataResponseShippingMethods = query.AsNoTracking().Select(item => _shippingMethodConverter.EntityToDTO(item));
            result.Succeeded = true;
            return result;
        }
    }
}
