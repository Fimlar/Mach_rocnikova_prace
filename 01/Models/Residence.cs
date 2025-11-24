using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.DirectoryServices.ActiveDirectory;

namespace Rocnikovka_first.Models
{
    public class Residence
    {
        [Key]
        public int id { get; set; }
        public int personId { get; set; }
        public Person person { get; set; } = null!;
        public string street { get; set; } = null!;
        public string postal_number { get; set; } = null!;
        public string city_part { get; set; } = null!;
        public int psc {  get; set; }
    }
}
