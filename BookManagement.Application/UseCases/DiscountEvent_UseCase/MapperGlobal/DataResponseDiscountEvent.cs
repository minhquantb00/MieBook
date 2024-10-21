using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.UseCases.DiscountEvent_UseCase.MapperGlobal
{
    public class DataResponseDiscountEvent
    {
        public long Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public double DiscountPercent { get; set; }
        public string DiscoutEventStatus { get; set; }
    }
}
