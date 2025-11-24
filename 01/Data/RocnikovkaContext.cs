using Rocnikovka_first.Models;
using Microsoft.EntityFrameworkCore;

namespace Rocnikovka_first.Data
{
    public class RocnikovkaContext : DbContext
    {
        public DbSet<Person> Person { get; set; } = null!;
        //public DbSet<Excuse> Excuse { get; set; } = null!;
        public DbSet<Representative> Representative { get; set; } = null!;
        public DbSet<Residence> Residence { get; set; } = null!;
        public DbSet<Role> Role { get; set; } = null!;
        public DbSet<Team> Team { get; set; } = null!;
        public DbSet<Training> Training { get; set; } = null!;
        public DbSet<Attendance> Attendance { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rocnikovka_first;Integrated Security=True;");
        }
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Excuse → Person (member)
            modelBuilder.Entity<Excuse>()
                .HasOne(e => e.person)
                .WithMany()
                .HasForeignKey(e => e.personId)
                .OnDelete(DeleteBehavior.Restrict);

            // Excuse → Representative (excuser)
            modelBuilder.Entity<Excuse>()
                .HasOne(e => e.excuser)
                .WithMany()
                .HasForeignKey(e => e.excuserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Representative → Person
            modelBuilder.Entity<Representative>()
                .HasOne(r => r.person)
                .WithMany()
                .HasForeignKey(r => r.personId)
                .OnDelete(DeleteBehavior.Restrict);
        }*/



    }
}
