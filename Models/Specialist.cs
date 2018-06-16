using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Specialist
    {
        public int Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String CompanyName { get; set; }
        public String ServiceDescription { get; set; }
        public int DocumentTypeId { get; set; }
        public String DocumentNumber { get; set; }
        public String PhoneNumber { get; set; }
        public String Facebook { get; set; }
        public String WebSite { get; set; }
        public String Address { get; set; }
        public String Reference { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { set; get; }
        public Boolean Acredited { get; set; }
        public Boolean MemberShip { set; get; }
        public decimal Rate { get; set; }
        public Boolean Online { get; set; }
        public Boolean State { get; set; }        
    }
}