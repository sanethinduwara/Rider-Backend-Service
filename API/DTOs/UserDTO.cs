﻿using System;
using System.Collections.Generic;
using System.Text;

namespace API.DTOs
{
    class UserDTO
    {

        public Guid Id { get; set; }

      
        public string UserName { get; set; }


        public string Email { get; set; }

        public int Score { get; set; }


        public string ProfileImage { get; set; }

    }
}
