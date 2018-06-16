using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public int CustomerId { get;set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public Byte State { get; set; }
    }
}