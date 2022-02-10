using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        public string Address { get; set; }
        //[Required]
        public string Telephone { get; set; }
        // [Required]
        // [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }
    }
}
