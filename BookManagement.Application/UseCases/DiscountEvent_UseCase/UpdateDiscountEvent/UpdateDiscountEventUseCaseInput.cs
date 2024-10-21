using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.UpdateDiscountEvent
{
    public class UpdateDiscountEventUseCaseInput
    {
        public long Id { get; set; }
        public string? EventName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public double? DiscountPercent { get; set; }
        [DataType(DataType.Upload)]
        public Enumerate.VoucherStatus? DiscoutEventStatus { get; set; }
    }
}
