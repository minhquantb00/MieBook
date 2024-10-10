using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Cart : BaseEntity<long>, IHasCreationTime, IHasModificationTime
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<CartItem>? CartItems { get; set; }
    }
}
