﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.ResponseModels
{
    public class DataResponseLogin
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
