using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class BillDetail : BaseEntity<long>
    {
        public long BillId { get; set; }
        public virtual Bill? Bill { get; set; }
        public long BookId { get; set; }
        public virtual Book? Book { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Note { get; set; }
    }
}
