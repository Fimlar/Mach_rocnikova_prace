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

        // pro vybírání co chceš zobrazit
        public ICollection<Residence> Residences { get; set; } = new List<Residence>();
        
        // public ICollection<Training> Trainings { get; set; } = new List<Training>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<Excuse> Excuses { get; set; } = new List<Excuse>();


        [Flags]
        public enum PersonIncludeOptions
        {
            None = 0,
            Team = 1 << 0,
            Residences = 1 << 1,
            // Trainings = 1 << 2,
            Attendances = 1 << 3,
            Excuses = 1 << 4,
        }
    }
}
