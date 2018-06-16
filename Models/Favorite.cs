using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Favorite
    {
       public int Id {get;set;}
       public int CustomerId{get;set;}
       public int SpecialistId{get;set;}
       public Boolean Hidden { get; set; }
    }
}