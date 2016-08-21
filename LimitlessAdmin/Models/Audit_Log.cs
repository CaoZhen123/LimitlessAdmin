using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LimitlessAdmin.Models
{
    public class Audit_Log
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Operation { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public virtual Organization Organization { get; set; }
    }
}