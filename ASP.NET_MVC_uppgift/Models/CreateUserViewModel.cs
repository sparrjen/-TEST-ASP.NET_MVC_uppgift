﻿using ASP.NET_MVC_uppgift.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_MVC_uppgift.Models
{
    public class CreateUserViewModel : AppUser
    {
        public string Password { get; set; }
    }
}
