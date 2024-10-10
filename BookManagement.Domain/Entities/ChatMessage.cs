using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class ChatMessage : BaseEntity<long>, IHasCreationTime, IDeletable
    {
        public long ConversationId { get; set; }
        public virtual Conversation? Conversation { get; set; }
        public string Content { get; set; }
        public string Photo {  get; set; }
        public long CreatorId { get; set; }
        public virtual Participant? Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public long UserDeleteId { get; set; }
        public virtual User? UserDelete { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<ChatMessageParticipantStates>? ChatMessageParticipantStates { get; set; }
    }
}
