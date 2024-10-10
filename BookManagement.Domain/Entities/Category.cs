using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Category : BaseEntity<long>, IHasCreationTime, IHasModificationTime
    {
        public string Name { get; set; }
        public int NumberOfProducts { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
