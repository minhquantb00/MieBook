using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Commons.Features
{
    public interface IHasModificationTime
    {
        DateTime? UpdateTime { get; set; }
    }
}
