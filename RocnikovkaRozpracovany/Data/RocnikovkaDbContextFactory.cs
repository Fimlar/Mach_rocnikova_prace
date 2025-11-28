using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach_rocnikova_prace.Data
{
    public class RocnikovkaDbContextFactory : IDesignTimeDbContextFactory<RocnikovkaDbContext>
    {
        public RocnikovkaDbContext CreateDbContext(string[] args = null!)
        {
            var options = new DbContextOptionsBuilder<RocnikovkaDbContext>();
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MachRocnikovka;Integrated Security=True;");

            return new RocnikovkaDbContext(options.Options);
        }
    }
}
