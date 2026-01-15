using Mach_rocnikova_prace.Models;
using Microsoft.EntityFrameworkCore;

namespace Mach_rocnikova_prace.Data
{
    public class RocnikovkaDbContext : DbContext
    {
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;

        public RocnikovkaDbContext(DbContextOptions options) : base(options) { }
    }
}
