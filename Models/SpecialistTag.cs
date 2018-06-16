using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class SpecialistTag
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int SpecialistId { get; set; }
    }
}