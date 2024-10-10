using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class EventBook : BaseEntity<long>
    {
        public long BookId { get; set; }
        public virtual Book? Book { get; set; }
        public long DiscountEventId { get; set; }
        public virtual DiscountEvent? DiscountEvent { get; set; }
    }
}
