﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularStarted.Models
{
    public class Empleat
    {
        [Key]
        public long Id { get; set; }
        public string Nom { get; set; }
        public string Cognom { get; set; }
        public string Càrrec { get; set; }
        public string Sou { get; set; }

        public Empleat()
        {
            Id = 0;
            Nom = "";
            Cognom = "";
            Càrrec = "";
            Sou = "";
        }
    }
}
