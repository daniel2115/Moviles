using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Specialist
    {
        public int id { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String companyName { get; set; }
        public String serviceDescription { get; set; }
        public int documentTypeId { get; set; }
        public String documentNumber { get; set; }
        public String phoneNumber { get; set; }
        public String facebook { get; set; }
        public String webSite { get; set; }
        public String address { get; set; }
        public String reference { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { set; get; }
        public Boolean acredited { get; set; }
        public Boolean memberShip { set; get; }
        public decimal rate { get; set; }
        public Boolean online { get; set; }
        public Boolean state { get; set; }        
    }
}