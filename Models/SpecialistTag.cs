﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosMovilkes.Models
{
    public class SpecialistTag
    {
        public int id { get; set; }
        public int tagId { get; set; }
        public int specialistId { get; set; }
    }
}