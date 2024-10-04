using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class MediaStorage : BaseEntity<Guid>
    {
        public byte[] Data { get; set; }
    }
}
