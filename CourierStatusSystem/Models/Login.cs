using System;
using System.ComponentModel.DataAnnotations;

namespace CourierStatusSystem.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username is empty")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        public string Password { get; set; }
    }
}
