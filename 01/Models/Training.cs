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
        public int id { get; set; }

        [Column(TypeName="DATE")]
        public DateTime date { get; set; }

        [Column(TypeName ="TIME")]
        public TimeOnly start_time { get; set; }

        [Column(TypeName = "TIME")]
        public TimeOnly end_time { get; set; }
        public string? location { get; set; }
    }
}
