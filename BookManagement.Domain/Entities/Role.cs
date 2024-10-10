using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Role : BaseEntity<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
