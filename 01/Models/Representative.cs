using System.ComponentModel.DataAnnotations;

namespace Rocnikovka_first.Models
{
    public class Representative
    {
        [Key]
        public int Representative_ID { get; set; }
        public int Member_ID { get; set; }
        public Member Member { get; set; } = null!;
        public string Last_name { get; set; } = null!;
        public string First_name { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public int? Telephone { get; set; }
    }
}