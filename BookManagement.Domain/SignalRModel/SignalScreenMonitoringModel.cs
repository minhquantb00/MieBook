﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.SignalRModel
{
    public class SignalScreenMonitoringModel
    {
        public string Action { get; set; }
        public SignalData SignalData { get; set; }
    }
}
