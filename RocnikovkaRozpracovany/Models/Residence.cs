using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mach_rocnikova_prace.Models
{
    public class Residence : DomainObject
    {
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;

        [Required]
        public string PostalNumber { get; set; } = null!;

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string City { get; set; } = null!;
    }
}
