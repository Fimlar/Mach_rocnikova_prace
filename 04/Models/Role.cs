using System.ComponentModel.DataAnnotations;

namespace Mach_rocnikova_prace.Models
{
    public class Role : DomainObject
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
