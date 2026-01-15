using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mach_rocnikova_prace.Models
{
    public class Person : DomainObject
    {
        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "DATE")]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string BirthNumber { get; set; } = null!;

        public string InsuranceCompanyName { get; set; } = null!;

        public string InsuranceCompanyId { get; set;} = null!;

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; } = null!;

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;

        [Required]
        public string PostalNumber { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        public bool Active { get; set; }
    }
}
