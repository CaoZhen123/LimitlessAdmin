using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LimitlessAdmin.Models
{
    public class AnswerOption
    {
        public int ID { get; set; }
        public int Option_Flag { get; set; }
        public virtual QuestionAttempted QuestionAttempted { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Organization Organization { get; set; }
    }
}