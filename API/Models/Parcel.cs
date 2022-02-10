using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Parcel
    {
        public int id { get; set; }
        public string trackingNum { get; set; }
        public string parcelStatus { get; set; }
        public string senderName { get; set; }
        public string senderEmail { get; set; }
        public string senderAddressLine1 { get; set; }
        public string senderAddressLine2 { get; set; }
        public string senderPostcode { get; set; }
        public string senderCity { get; set; }
        public string senderState { get; set; }
        public string senderContact { get; set; }
        public string senderAltContact { get; set; }
        public string recipientName { get; set; }
        public string recipientEmail { get; set; }
        public string recipientAddressLine1 { get; set; }
        public string recipientAddressLine2 { get; set; }
        public string recipientPostcode { get; set; }
        public string recipientCity { get; set; }
        public string recipientState { get; set; }
        public string recipientContact { get; set; }
        public string recipientAltContact { get; set; }
       
    }
}
