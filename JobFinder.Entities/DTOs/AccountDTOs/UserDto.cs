﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder.Entities.DTOs.AccountDTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Roles { get; set; }
    }
}
