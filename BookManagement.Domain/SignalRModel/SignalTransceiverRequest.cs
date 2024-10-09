using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.SignalRModel
{
    public class SignalTransceiverRequest
    {
        public object init { get; set; }
        public string Kind { get; set; }
    }
}
