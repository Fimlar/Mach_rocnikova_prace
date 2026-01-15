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
    public class TeamDataService : GenericDataService<Team>
    {
        private readonly RocnikovkaDbContextFactory _contextFactory;

        public TeamDataService(RocnikovkaDbContextFactory contextFactory)
            : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public override async Task<bool> Delete(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            bool isUsed = await context.People.AnyAsync(p => p.TeamId == id);
            if (isUsed)
                throw new EntityInUseException("Tým", id);

            var team = await context.Teams.FindAsync(id);
            if (team == null)
                return false;

            context.Teams.Remove(team);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
