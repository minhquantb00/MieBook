﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Handle.Media
{
    public class Request_UploadPhoto
    {
        public Stream FileStream { get; set; }
        public string SavePath { get; set; }
        public string FileName { get; set; }
    }
}
