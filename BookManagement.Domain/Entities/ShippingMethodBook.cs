using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class ShippingMethodBook : BaseEntity<long>, IActivatable
    {
        public long BookId { get; set; }
        public virtual Book? Book { get; set; }
        public long ShippingMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public bool IsActive { get; set; }
    }
}
