﻿using System.ComponentModel.DataAnnotations;

namespace ETickets.ModelView
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
