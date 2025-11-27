using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka.Domain.Models
{
    public class Representative : DomainObject
    {
        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; } = null!;

        public string? Email { get; set; }

        public int? PhoneNumber { get; set; }
    }
}
