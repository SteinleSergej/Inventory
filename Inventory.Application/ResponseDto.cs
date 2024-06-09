﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application
{
    public class ResponseDto
    {
        public object? Data { get; set; }
        public string Message { get; set; } = "";
        public bool IsSuccess { get; set; }=true;
    }
}
