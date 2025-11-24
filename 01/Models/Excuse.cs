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
        public int id { get; set; }
        public int personId { get; set; }
        //public int excuserId { get; set; }
        public Person person { get; set; } = null!;
        //public Representative excuser { get; set; } = null!;
        public string excuse_date { get; set; } = null!;
        public string message { get; set; } = null!;
    }
}
