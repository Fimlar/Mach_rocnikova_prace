using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka_first.Models
{
    public class Excuse
    {
        [Key]
        public int Excuse_ID { get; set; }
        public int Member_ID { get; set; }
        public int Excuser_ID { get; set; }
        public Member Member { get; set; } = null!;
        public Representative Excuser { get; set; } = null!;
        public string Excuse_date { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
