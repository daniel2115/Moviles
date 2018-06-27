using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Problem
    {
        public int id { get; set; }
        //public int customerId { get;set; }
        public Customer customer = new Customer();
        public String title { get; set; }
        public String description { get; set; }
        public Byte state { get; set; }
    }
}