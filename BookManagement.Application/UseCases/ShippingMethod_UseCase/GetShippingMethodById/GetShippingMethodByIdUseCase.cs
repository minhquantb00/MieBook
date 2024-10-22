using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.GetRoleById;
using BookManagement.Application.UseCases.ShippingMethod_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.GetShippingMethodById
{
    public class GetShippingMethodByIdUseCase : IUseCaseGetById<long, GetShippingMethodByIdUseCaseOutput>
    {
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        private readonly ShippingMethodConverter _shippingMethodConverter;
        public GetShippingMethodByIdUseCase(IRepository<ShippingMethod> shippingMethodRepository, ShippingMethodConverter shippingMethodConverter)
        {
            _shippingMethodConverter = shippingMethodConverter;
            _shippingMethodRepository = shippingMethodRepository;
        }
        public async Task<GetShippingMethodByIdUseCaseOutput> ExcuteAsync(long id)
        {
            GetShippingMethodByIdUseCaseOutput result = new GetShippingMethodByIdUseCaseOutput
            {
                Succeeded = false,
            };
            var query = await _shippingMethodRepository.GetByIdAsync(id);
            if (query == null)
            {
                result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                return result;
            }
            result.Succeeded = true;
            result.DataResponseShippingMethod = _shippingMethodConverter.EntityToDTO(query);
            return result;
        }
    }
}
