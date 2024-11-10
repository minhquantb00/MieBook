using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.ShippingMethod_UseCase.CreateShippingMethod
{
    public class CreateShippingMethodUseCase : IUseCase<CreateShippingMethodUseCaseInput, CreateShippingMethodUseCaseOutput>
    {
        private readonly IRepository<ShippingMethod> _shippingMethodRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateShippingMethodUseCase(IRepository<ShippingMethod> shippingMethodRepsitory, IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _shippingMethodRepository = shippingMethodRepsitory;
        }
        public async Task<CreateShippingMethodUseCaseOutput> ExcuteAsync(CreateShippingMethodUseCaseInput input)
        {
            CreateShippingMethodUseCaseOutput result = new CreateShippingMethodUseCaseOutput
            {
                Succeeded = false,
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
                ShippingMethod shippingMethod = new ShippingMethod
                {
                    IsActive = true,
                    CreateTime = DateTime.Now,
                    Name = input.Name,
                    Status = Commons.Enums.Enumerate.ShippingMethodStatus.ChuaApDung,
                };
                shippingMethod = await _shippingMethodRepository.CreateAsync(shippingMethod);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }
    }
}
