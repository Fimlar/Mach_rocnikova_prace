using System.ComponentModel.DataAnnotations;

namespace Rocnikovka_first.Models
{
    public class Team
    {
        [Key]
        public int Team_ID { get; set; }
        public string Name { get; set; } = null!;
    }
}