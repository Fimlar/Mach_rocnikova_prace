using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mach_rocnikova_prace.Models
{
    public class Excuse : DomainObject
    {
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        [Column(TypeName ="DATE")]
        public DateOnly ExcuseDate { get; set; }

        public string? Message { get; set; } = null!;
    }
}
