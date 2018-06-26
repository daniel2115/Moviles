using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class Favorite
    {
       public int id {get;set;}
       public int customerId{get;set;}
       public int specialistId{get;set;}
       public Boolean hidden { get; set; }
    }
}