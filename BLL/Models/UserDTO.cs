﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class UserDTO
    {
        public string  Username { get; set; }
        public string Token { get; set; }
        public string PhotoUrl{get;set; }
        public string KnownAs {get;set; }
        public string Gender { get; set; }
    }
}
