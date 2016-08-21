using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LimitlessAdmin.Models
{
    public class Subject
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Descirption { get; set; }

        public int Icon { get; set; }

        public virtual Organization Organization { get; set; }
    }
}