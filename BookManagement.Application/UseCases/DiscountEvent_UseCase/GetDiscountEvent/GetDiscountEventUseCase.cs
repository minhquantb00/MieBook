using BookManagement.Application.IUseCases;
using BookManagement.Application.UseCases.DiscountEvent_UseCase.MapperGlobal;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEvent
{
    public class GetDiscountEventUseCase : IUseCase<GetDiscountEventUseCaseInput, GetDiscountEventUseCaseOutput>
    {
        private readonly IRepository<DiscountEvent> _discountEventRepository;
        private readonly DiscountEventConverter _discountEventConverter;
        public GetDiscountEventUseCase(IRepository<DiscountEvent> discountEventRepository, DiscountEventConverter discountEventConverter)
        {
            _discountEventRepository = discountEventRepository;
            _discountEventConverter = discountEventConverter;
        }

        public async Task<GetDiscountEventUseCaseOutput> ExcuteAsync(GetDiscountEventUseCaseInput input)
        {
            GetDiscountEventUseCaseOutput result = new GetDiscountEventUseCaseOutput
            {
                Succeeded = false
            };
            var query = await _discountEventRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(input.EventName))
            {
                query = query.AsNoTracking().Where(record => record.EventName.Contains(input.EventName));
            }
            if (input.StartTime.HasValue && !input.EndTime.HasValue)
            {
                query = query.AsNoTracking().Where(x => x.StartTime >= input.StartTime);
            }
            if (input.StartTime.HasValue && input.EndTime.HasValue)
            {
                query = query.AsNoTracking().Where(x => x.StartTime >= input.StartTime && x.StartTime <= input.EndTime);
            }
            if (input.DiscountPercentStart.HasValue && !input.DiscountPercentEnd.HasValue)
            {
                query = query.AsNoTracking().Where(x => x.DiscountPercent >= input.DiscountPercentStart);
            }
            if (input.DiscountPercentStart.HasValue && input.DiscountPercentEnd.HasValue)
            {
                query = query.AsNoTracking().Where(x => x.DiscountPercent >= input.DiscountPercentStart && x.DiscountPercent <= input.DiscountPercentEnd);
            }
            if (input.DiscoutEventStatus.HasValue)
            {
                query = query.AsNoTracking().Where(record => record.DiscoutEventStatus == input.DiscoutEventStatus);
            }

            result.DataResponseDiscountEvents = query.AsNoTracking().Select(item => _discountEventConverter.EntityToDTO(item));
            result.Succeeded = true;
            return result;
        }

        public Task<GetDiscountEventUseCaseOutput> ExcuteAsync(long? id, GetDiscountEventUseCaseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
