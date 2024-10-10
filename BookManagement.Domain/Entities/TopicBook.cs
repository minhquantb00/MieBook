using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class TopicBook : BaseEntity<long>
    {
        public string Banner {  get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
