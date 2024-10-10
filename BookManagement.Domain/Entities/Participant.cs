using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class Participant : BaseEntity<long>, IHasCreationTime
    {
        public long ConversationId { get; set; }
        public virtual Conversation? Conversation { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual ICollection<ChatMessageParticipantStates>? ChatMessageParticipantStates { get; set; }
        public virtual ICollection<Participant>? Participants { get; set; }
    }
}
