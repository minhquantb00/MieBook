using BookManagement.Application.IUseCases;
using BookManagement.Commons.Enums;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.UpdateDiscountEvent
{
    public class UpdateDiscountEventUseCase : IUseCase<UpdateDiscountEventUseCaseInput, UpdateDiscountEventUseCaseOutput>
    {
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public UpdateDiscountEventUseCase(IRepository<DiscountEvent> discountEventRepository, IHttpContextAccessor contextAccessor)
        {
            _discountEventRepository = discountEventRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<UpdateDiscountEventUseCaseOutput> ExcuteAsync(UpdateDiscountEventUseCaseInput input)
        {
            UpdateDiscountEventUseCaseOutput result = new UpdateDiscountEventUseCaseOutput
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
                var discountEvent = await _discountEventRepository.GetByIdAsync(input.Id);
                if (discountEvent == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                discountEvent.StartTime = input.StartTime.HasValue ? input.StartTime.Value : discountEvent.StartTime;
                discountEvent.DiscoutEventStatus = input.DiscoutEventStatus.HasValue ? (Enumerate.VoucherStatus) input.DiscoutEventStatus : discountEvent.DiscoutEventStatus;
                discountEvent.EventName = !string.IsNullOrEmpty(input.EventName) ? input.EventName : discountEvent.EventName;   
                discountEvent.DiscountPercent = input.DiscountPercent.HasValue ? input.DiscountPercent.Value : discountEvent.DiscountPercent;
                discountEvent.Description = !string.IsNullOrEmpty(input.Description) ? input.Description : discountEvent.Description;
                discountEvent.EndTime = input.EndTime.HasValue ? input.EndTime.Value : discountEvent.EndTime;
                discountEvent.Logo = !string.IsNullOrEmpty(input.Logo) ? input.Logo : discountEvent.Logo;
                discountEvent = await _discountEventRepository.UpdateAsync(discountEvent);
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
