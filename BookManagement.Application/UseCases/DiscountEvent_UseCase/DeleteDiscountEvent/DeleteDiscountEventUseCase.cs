using BookManagement.Application.IUseCases;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.DeleteDiscountEvent
{
    public class DeleteDiscountEventUseCase : IUseCase<DeleteDiscountEventUseCaseInput, DeleteDiscountEventUseCaseOutput>
    {
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        public DeleteDiscountEventUseCase(IRepository<DiscountEvent> discountEventRepository, IHttpContextAccessor contextAccessor)
        {
            _discountEventRepository = discountEventRepository;
            _contextAccessor = contextAccessor;
        }

        public async Task<DeleteDiscountEventUseCaseOutput> ExcuteAsync(DeleteDiscountEventUseCaseInput input)
        {
            DeleteDiscountEventUseCaseOutput result = new DeleteDiscountEventUseCaseOutput
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
                if(discountEvent == null)
                {
                    result.Errors = new string[] { "Không tìm thấy dữ liệu" };
                    return result;
                }
                await _discountEventRepository.DeleteAsync(discountEvent.Id);
                result.Succeeded = true;
                return result;
            }catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
                return result;
            }
        }

        public Task<DeleteDiscountEventUseCaseOutput> ExcuteAsync(long? id, DeleteDiscountEventUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
