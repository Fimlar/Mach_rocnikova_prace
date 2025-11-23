using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.DirectoryServices.ActiveDirectory;

namespace Rocnikovka_first.Models
{
    public class Member
    {
        [Key]
        public int Member_ID { get; set; }

        public string Last_name { get; set; } = null!;
        public string First_name { get; set; } = null!;

        [Column(TypeName ="DATE")]
        public DateTime Date_of_birth { get; set; }

        public int Birth_number { get; set; }
        public string Health_insurance_name { get; set; } = null!;
        public int Health_insurance_number { get; set; }
        public int Team_ID { get; set; }
        public Team Team { get; set; } = null!;
        public int Role_ID { get; set; }
        public Role Role { get; set; } = null!;
        public bool Active { get; set; }
    }
}
