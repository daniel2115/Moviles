using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Customer
    {
        public int Id { set; get; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public int DocumentTypeId { get; set; }
        public String DocumentNumber { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String Reference { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
        public Decimal Rate { get; set; }
        public Boolean Online { get; set; }
        public Boolean State { get; set; }
    }
}