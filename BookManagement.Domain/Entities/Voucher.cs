using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Voucher : BaseEntity<long>, IHasCreationTime
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double DiscountPercent { get; set; } = 0.0;
        public DateTime CreateTime { get; set; }
        public virtual ICollection<UserVoucher>? UserVouchers { get; set; }
    }
}
