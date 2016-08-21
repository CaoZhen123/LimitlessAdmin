using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LimitlessAdmin.Models
{
    public class SubObjective
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        public int NumberOfWrongGlobal { get; set; }
        public int NumberOfCorrectGlobal { get; set; }

        public virtual Organization Organization { get; set; }
    }
}