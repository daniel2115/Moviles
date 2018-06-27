using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Customer
    {
        public int id { set; get; }
        public String login { get; set; }
        public String password { get; set; }
        public String name { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
     
        public DocumentType document = new DocumentType();
        public String phoneNumber { get; set; }
        public String address { get; set; }
        public String reference { get; set; }
        public Decimal latitude { get; set; }
        public Decimal longitude { get; set; }
        public Decimal rate { get; set; }
        public Boolean online { get; set; }
        public Boolean state { get; set; }
    }
}