using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Additional
    {
        public int Id { get; set; }
        public int QuotationId { get; set; }
        public Decimal Price { get; set; }
        public String Description { get;set; }
        public Byte State { get; set; }
    }
}