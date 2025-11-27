using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka.Domain.Models
{
    public class Attendace : DomainObject
    {
        [Required]
        public int TrainingId { get; set; }

        [Required]
        [ForeignKey("TrainingId")]
        public Training Training { get; set; } = null!;

        [Required]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        public int State { get; set; }
    }
}
