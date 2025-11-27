using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka.Domain.Models
{
    public class Training : DomainObject
    {
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        public TimeOnly StartTime { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        public TimeOnly EndTime { get; set; }

        public string? Location { get; set; }
    }
}
