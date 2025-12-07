using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mach_rocnikova_prace.Models
{
    public class Training : DomainObject
    {
        [Required]
        [Column(TypeName = "DATE")]
        public DateOnly Date { get; set; }

        [Required]
        [Column(TypeName ="TIME")]
        public TimeOnly StartTime { get; set; }

        [Required]
        [Column(TypeName = "TIME")]
        public TimeOnly EndTime { get; set; }

        public string? Location { get; set; }
    }
}
