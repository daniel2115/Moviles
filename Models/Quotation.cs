using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Quotation
    {
        public int id { get; set; }
        //public int problemId { get; set; }
        public Problem problem = new Problem();
        //public int specialistId { get; set; }
        public Specialist specialist = new Specialist();
        public String description { get; set; }
        public Decimal price { get; set; }
        public Byte estimatedTime { get; set; }
        public Boolean includesMaterial { get; set; }
        public Byte state { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public Decimal finalPrice { get; set; }
        public Decimal specialistRate { get; set; }
        public String specialistComment { get; set; }
        public Decimal customerRate { get; set; }
        public String customerComment { get; set; }
    }
}