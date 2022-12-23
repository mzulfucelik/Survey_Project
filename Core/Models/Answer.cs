using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Answer : BaseEntity
    {
        public int AnswerId { get; set; }
        public string AnswerType { get; set; }
        public string Content { get; set; }
 
    }
}
