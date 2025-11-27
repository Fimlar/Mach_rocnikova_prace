using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka.Domain.Models
{
    public class Residence : DomainObject
    {
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;

        [Required]
        public string PostalNumber { get; set; } = null!;

        [Required]
        public int PostalCode { get; set; }

        [Required]
        public string City { get; set; } = null!;
    }
}
