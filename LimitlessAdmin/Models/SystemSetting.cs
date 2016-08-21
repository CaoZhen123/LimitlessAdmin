using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LimitlessAdmin.Models
{
    public class SystemSetting
    {
        public int ID { get; set; }
 
        [StringLength(100)]
        public string Remark { get; set;}

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public virtual Organization Organization { get; set; }

    }
}