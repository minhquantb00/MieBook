﻿using BookManagement.Commons.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Entities
{
    public class UserRole : BaseEntity<long>
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long? RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
