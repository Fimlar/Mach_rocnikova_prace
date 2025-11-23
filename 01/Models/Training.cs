using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka_first.Models
{
    public class Training
    {
        [Key]
        public int Training_ID { get; set; }

        [Column(TypeName="DATE")]
        public DateTime Date { get; set; }

        [Column(TypeName ="TIME")]
        public TimeOnly Start_time { get; set; }

        [Column(TypeName = "TIME")]
        public TimeOnly End_time { get; set; }
        public string? Location { get; set; }
    }
}
