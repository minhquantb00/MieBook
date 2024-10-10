using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Conversation : BaseEntity<long>, IHasCreationTime, IDeletable
    {
        public string Title { get; set; }
        public string Creator {  get; set; }
        public DateTime? DeleteTime { get; set; }
        public long UserDeleteId { get; set; }
        public virtual User? UserDelete { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Participant>? Participants { get; set; }
        public virtual ICollection<ChatMessage>? ChatMessages { get; set; }
    }
}
