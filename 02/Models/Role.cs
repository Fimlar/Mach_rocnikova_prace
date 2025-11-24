using System.ComponentModel.DataAnnotations;

namespace Rocnikovka_first.Models
{
    public class Role
    {
        [Key]
        public int Role_ID { get; set; }
        public string Name { get; set; } = null!;
    }
}