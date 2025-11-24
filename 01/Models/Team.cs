using System.ComponentModel.DataAnnotations;

namespace Rocnikovka_first.Models
{
    public class Team
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = null!;
    }
}