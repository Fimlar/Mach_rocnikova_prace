using System.ComponentModel.DataAnnotations;

namespace Rocnikovka_first.Models
{
    public class Representative
    {
        [Key]
        public int id { get; set; }
        public int personId { get; set; }
        public Person person { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public string first_name { get; set; } = null!;
        public string mail { get; set; } = null!;
        public int? telephone { get; set; }
    }
}