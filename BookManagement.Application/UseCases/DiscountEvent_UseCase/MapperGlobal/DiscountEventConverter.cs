using BookManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.MapperGlobal
{
    public class DiscountEventConverter
    {
        public DataResponseDiscountEvent EntityToDTO(DiscountEvent entity)
        {
            return new DataResponseDiscountEvent
            {
                Description = entity.Description,
                DiscountPercent = entity.DiscountPercent,
                DiscoutEventStatus = entity.DiscoutEventStatus.ToString(),
                EndTime = entity.EndTime,
                EventName = entity.EventName,
                Id = entity.Id,
                Logo = entity.Logo,
                StartTime = entity.StartTime,
            };
        }
    }
}
