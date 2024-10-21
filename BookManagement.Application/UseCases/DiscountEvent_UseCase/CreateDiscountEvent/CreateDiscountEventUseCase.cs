using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.CreateDiscountEvent
{
    public class CreateDiscountEventUseCase : IUseCase<CreateDiscountEventUseCaseInput, CreateDiscountEventUseCaseOutput>
    {
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public CreateDiscountEventUseCase(IRepository<DiscountEvent> discountEventRepository, IHttpContextAccessor contextAccessor)
        {
            _discountEventRepository = discountEventRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<CreateDiscountEventUseCaseOutput> ExcuteAsync(CreateDiscountEventUseCaseInput input)
        {
            CreateDiscountEventUseCaseOutput result = new CreateDiscountEventUseCaseOutput
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
                DiscountEvent discountEvent = new DiscountEvent
                {
                    Description = input.Description,
                    DiscountPercent = input.DiscountPercent,
                    DiscoutEventStatus = input.DiscoutEventStatus,
                    EndTime = input.EndTime,
                    EventName = input.EventName,
                    Logo = input.Logo,
                    StartTime = input.StartTime,
                };
                discountEvent = await _discountEventRepository.CreateAsync(discountEvent);
                result.Succeeded = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<CreateDiscountEventUseCaseOutput> ExcuteAsync(long? id, CreateDiscountEventUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
