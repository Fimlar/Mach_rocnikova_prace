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
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int BirthNumber { get; set; }

        public string InsuranceCompanyName { get; set; } = null!;

        public int InsuranceCompanyId { get; set;}

        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; } = null!;

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; } = null!;

        public bool Active { get; set; }
    }
}
