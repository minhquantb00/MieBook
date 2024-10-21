using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.CreateDiscountEvent
{
    public class CreateDiscountEventUseCaseInput
    {
        [Required(ErrorMessage = "Event Name is required")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "Start Time is required")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "End Time is required")]
        public DateTime EndTime { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Logo is required")]
        public string Logo { get; set; }
        [Required(ErrorMessage = "Discount percent is required")]
        public double DiscountPercent { get; set; }
        [DataType(DataType.Upload)]
        public Enumerate.VoucherStatus DiscoutEventStatus { get; set; }
    }
}
