using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LimitlessAdmin.Models
{
    public class Question
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Content { get; set; }
        
        public virtual Organization Organization { get; set; }
    }
}