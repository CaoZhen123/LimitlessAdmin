using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LimitlessAdmin.Models
{
    public class Answer
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        public int Answer_Flag { get; set; }

        [StringLength(200)]
        public string Explanation { get; set; }

        public Organization Organization { get; set; }
    }
}