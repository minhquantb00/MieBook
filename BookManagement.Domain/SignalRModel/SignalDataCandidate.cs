﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.SignalRModel
{
    public class SignalDataCandidate
    {
        public string Candidate { get; set; }
        public int SdpMLineIndex { get; set; }
        public string SdpMid { get; set; }
    }
}
