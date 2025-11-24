using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.DirectoryServices.ActiveDirectory;

namespace Rocnikovka_first.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        public string last_name { get; set; } = null!;
        public string first_name { get; set; } = null!;

        [Column(TypeName ="DATE")]
        public DateTime date_of_birth { get; set; }

        public int birth_number { get; set; }
        public string health_insurance_name { get; set; } = null!;
        public int health_insurance_number { get; set; }
        public int team_id { get; set; }
        public Team team { get; set; } = null!;
        public int role_id { get; set; }
        public Role role { get; set; } = null!;
        public bool active { get; set; }
    }
}
