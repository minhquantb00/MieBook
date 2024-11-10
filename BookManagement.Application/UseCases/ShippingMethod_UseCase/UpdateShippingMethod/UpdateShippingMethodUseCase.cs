using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.UpdateRole;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.UpdateShippingMethod
{
    public class UpdateShippingMethodUseCase : IUseCase<UpdateShippingMethodUseCaseInput, UpdateShippingMethodUseCaseOutput>
    {
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateShippingMethodUseCase(IRepository<ShippingMethod> shippingMethodRepository, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _shippingMethodRepository = shippingMethodRepository;
        }
        public async Task<UpdateShippingMethodUseCaseOutput> ExcuteAsync(UpdateShippingMethodUseCaseInput input)
        {
            UpdateShippingMethodUseCaseOutput result = new UpdateShippingMethodUseCaseOutput
            {
                Succeeded = false
            };
            var currentUser = _contextAccessor.HttpContext.User;
            if (!currentUser.Identity.IsAuthenticated)
            {
                result.Errors = new string[] { "Người dùng chưa được xác thực" };
                return result;
            }
            if (!currentUser.IsInRole("Admin"))
            {
                result.Errors = new string[] { "Bạn không có quyền thực hiện chức năng này" };
                return result;
            }
            try
            {
                var shippingMethod = await _shippingMethodRepository.GetByIdAsync(input.Id);
                if (shippingMethod == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                shippingMethod.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : shippingMethod.Name;
                shippingMethod = await _shippingMethodRepository.UpdateAsync(shippingMethod);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
