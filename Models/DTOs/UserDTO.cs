﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Shop.Models.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
