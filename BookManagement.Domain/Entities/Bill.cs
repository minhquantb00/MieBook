using BookManagement.Commons.Base;
using BookManagement.Commons.Enums;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Bill : BaseEntity<long>, IHasCreationTime, IHasModificationTime
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long ShippingMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public long AddressUserId {  get; set; }
        public virtual AddressUser? AddressUser { get; set; }
        public string TradingCode { get; set; }
        public long PaymentMethodId { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? PayTime { get; set; }
        public double TotalPriceBeforeDiscount { get; set; }
        public Enumerate.BillStatus BillStatus { get; set; } = Enumerate.BillStatus.ChuaThanhToan;
        public string? Note { get; set; }
        public string? ReasonForRefusal { get; set; }
        public double TotalPriceAfterDiscount { get; set; }
        public long? UserVoucherId { get; set; }
        public virtual UserVoucher? UserVoucher { get; set; }
        public double ShippingFee { get; set; }
        public virtual ICollection<BillDetail>? BillDetails { get; set; }
    }
}
