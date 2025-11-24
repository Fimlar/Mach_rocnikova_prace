using System.ComponentModel.DataAnnotations;

namespace Rocnikovka_first.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = null!;
        public ICollection<Person> people { get; set; }

    }
}