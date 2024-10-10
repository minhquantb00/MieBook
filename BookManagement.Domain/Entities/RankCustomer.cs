using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class RankCustomer : BaseEntity<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double DiscountPercent { get; set; }
    }
}
