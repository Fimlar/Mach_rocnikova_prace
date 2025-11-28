using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mach_rocnikova_prace.Models
{
    public class Attendance : DomainObject
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
