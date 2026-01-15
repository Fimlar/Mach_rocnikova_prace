using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Exceptions;
using Mach_rocnikova_prace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach_rocnikova_prace.Services
{
    public class RoleDataService : GenericDataService<Role>
    {
        private readonly RocnikovkaDbContextFactory _contextFactory;

        public RoleDataService(RocnikovkaDbContextFactory contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public override async Task<bool> Delete(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            bool isUsed = await context.People.AnyAsync(p => p.RoleId == id);
            if (isUsed)
                throw new EntityInUseException("Role", id);

            var role = await context.Roles.FindAsync(id);
            if (role == null)
                return false;

            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
