using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LimitlessAdmin.Models
{
    public class Lesson
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Content { get; set; }
        
        public virtual SubObjective SubObjective { get; set; }
        public virtual Organization Organization { get; set; }
    }
}