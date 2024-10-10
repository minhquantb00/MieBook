using BookManagement.Commons.Base;
using BookManagement.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class DiscountEvent : BaseEntity<long>
    {
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public double DiscountPercent { get; set; } = 0.0;
        public Enumerate.VoucherStatus DiscoutEventStatus { get; set; } = Enumerate.VoucherStatus.ChuaApDung;
        public virtual ICollection<DiscountEvent>? DiscountEvents { get; set; }
    }
}
