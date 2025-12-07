using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mach_rocnikova_prace.Models
{
    public class Representative : DomainObject
    {
        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
