using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Additional
    {
        public int id { get; set; }
        public int quotationId { get; set; }
        public Decimal price { get; set; }
        public String description { get;set; }
        public Byte state { get; set; }
    }
}