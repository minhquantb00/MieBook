using BookManagement.Commons.Base;
using BookManagement.Commons.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class RefreshToken : BaseEntity<long>, IHasCreationTime
    {
        public string Token { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime ExpiredTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
