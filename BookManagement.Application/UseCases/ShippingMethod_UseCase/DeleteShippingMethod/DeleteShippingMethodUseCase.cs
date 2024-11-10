using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.Role_UseCase.DeleteRole;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.DeleteShippingMethod
{
    public class DeleteShippingMethodUseCase : IUseCase<DeleteShippingMethodUseCaseInput, DeleteShippingMethodUseCaseOutput>
    {
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteShippingMethodUseCase(IRepository<ShippingMethod> shippingMethodRepository, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _shippingMethodRepository = shippingMethodRepository;
        }
        public async Task<DeleteShippingMethodUseCaseOutput> ExcuteAsync(DeleteShippingMethodUseCaseInput input)
        {
            DeleteShippingMethodUseCaseOutput result = new DeleteShippingMethodUseCaseOutput
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
                await _shippingMethodRepository.DeleteAsync(shippingMethod.Id);
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
