﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Dto
{
    public class UserLoginDto
    {
        public string UsernameOrEmail { get; set; } = string.Empty;
        public string Password{ get; set; } = string.Empty;

    }
}
