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
    public class ShippingMethod : BaseEntity<long>, IHasCreationTime, IHasModificationTime, IActivatable
    {
        public string Name { get; set; }
        public Enumerate.ShippingMethodStatus Status { get; set; } = Enumerate.ShippingMethodStatus.ChuaApDung;
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<ShippingMethodBook>? ShippingMethodBooks { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
    }
}
