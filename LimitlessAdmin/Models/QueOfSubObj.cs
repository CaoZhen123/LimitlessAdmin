using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LimitlessAdmin.Models
{
    public class QueOfSubObj
    {
        public int ID { get; set; }

        public virtual SubObjective SubObjective { get; set; }
        public virtual Question Question { get; set; }
        public virtual Organization Organization { get; set; }
    }
}