using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka.Domain.Models
{
    public class Team : DomainObject
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
