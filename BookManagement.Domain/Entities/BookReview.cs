using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class BookReview : BaseEntity<long>
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long BookId { get; set; }
        public virtual Book? Book { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime ReviewTime { get; set; }
    }
}
