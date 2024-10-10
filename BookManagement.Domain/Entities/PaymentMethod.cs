using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class PaymentMethod : BaseEntity<long>
    {
        public string Name { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
    }
}
