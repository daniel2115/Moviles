using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Quotation
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public int SpecialistId { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
        public Byte EstimatedTime { get; set; }
        public Boolean IncludesMaterial { get; set; }
        public Byte State { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Decimal FinalPrice { get; set; }
        public Decimal SpecialistRate { get; set; }
        public String SpecialistComment { get; set; }
        public Decimal CustomerRate { get; set; }
        public String CustomerComment { get; set; }
    }
}