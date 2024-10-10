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
    public class UserVoucher : BaseEntity<long>, IHasCreationTime
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long VoucherId { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public Enumerate.VoucherStatus VoucherStatus { get; set; } = Enumerate.VoucherStatus.ChuaApDung;
        public virtual ICollection<Bill>? Bills { get; set; }
    }
}
