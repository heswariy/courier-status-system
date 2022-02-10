using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourierStatusSystem.Models
{
    public class Rider
    {
        [Required(ErrorMessage = "ID is empty")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")]
        public int riderId { get; set; }

        [Required(ErrorMessage = "Name is empty")]
        public string riderName { get; set; }

        [Required(ErrorMessage = "Email is empty")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email")]
        public string riderEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is empty")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Phone Number. Only numbers, '-' not required")]
        public string riderContact { get; set; }

        [Required(ErrorMessage = "Address is empty")]
        public string riderAddressLine1 { get; set; }

        public string riderAddressLine2 { get; set; }

        [Required(ErrorMessage = "City is empty")]
        public string riderCity { get; set; }

        [Required(ErrorMessage = "Postcode is empty")]
        public string riderPostcode { get; set; }

        [Required(ErrorMessage = "State is empty")]
        public string riderState { get; set; }

        [Required(ErrorMessage = "Username is empty")]
        public string riderUsername { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$",ErrorMessage = "Password must be at least 8 characters, contain at least one one lower case letter, one upper case letter, one digit and one special character. Valid special characters are -   @#$%^&+=")]
        public string riderPassword { get; set; }
        
    }
}
