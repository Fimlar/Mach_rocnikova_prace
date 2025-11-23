using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.DirectoryServices.ActiveDirectory;

namespace Rocnikovka_first.Models
{
    public class Residence
    {
        [Key]
        public int Residence_ID { get; set; }
        public int Member_ID { get; set; }
        public Member Member { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string Postal_number { get; set; } = null!;
        public string City_part { get; set; } = null!;
        public int PSC {  get; set; }
    }
}
