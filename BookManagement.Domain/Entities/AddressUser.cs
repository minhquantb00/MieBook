using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class AddressUser : BaseEntity<long>
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public string Address { get; set; }
        public bool? IsDefault { get; set; }
    }
}
