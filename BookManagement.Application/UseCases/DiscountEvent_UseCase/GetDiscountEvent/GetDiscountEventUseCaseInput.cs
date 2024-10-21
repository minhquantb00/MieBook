using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.GetDiscountEvent
{
    public class GetDiscountEventUseCaseInput
    {
        public string? EventName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double? DiscountPercentStart { get; set; }
        public double? DiscountPercentEnd { get; set; }
        [DataType(DataType.Upload)]
        public Enumerate.VoucherStatus? DiscoutEventStatus { get; set; }
    }
}
