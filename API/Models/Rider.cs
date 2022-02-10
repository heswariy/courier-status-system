using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Rider
    {
        public int riderId { get; set; }
        public string riderName { get; set; }
        public string riderEmail { get; set; }
        public string riderContact { get; set; }
        public string riderAddressLine1 { get; set; }
        public string riderAddressLine2 { get; set; }
        public string riderCity { get; set; }
        public string riderPostcode { get; set; }
        public string riderState { get; set; }
        public string riderUsername { get; set; }
        public string riderPassword { get; set; }
    }
}
