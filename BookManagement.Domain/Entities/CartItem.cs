using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class CartItem : BaseEntity<long>, IHasCreationTime, IHasModificationTime
    {
        public long CartId { get; set; }
        public virtual Cart? Cart { get; set; }
        public long BookId { get; set; }
        public virtual Book? Book { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
