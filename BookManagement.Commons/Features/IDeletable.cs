﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Commons.Features
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
