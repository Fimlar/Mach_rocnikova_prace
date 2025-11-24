using Rocnikovka_first.Models;
using Microsoft.EntityFrameworkCore;

namespace Rocnikovka_first.Data
{
    public class RocnikovkaContext : DbContext
    {
        public DbSet<Member> Members { get; set; } = null!;
        public DbSet<Excuse> Excuses { get; set; } = null!;
        public DbSet<Representative> Representatives { get; set; } = null!;
        public DbSet<Residence> Residences { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Training> Trainings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rocnikovka;Integrated Security=True;");
        }
    }
}
