using System.ComponentModel.DataAnnotations;

namespace Mach_rocnikova_prace.Models
{
    public class Team : DomainObject
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
