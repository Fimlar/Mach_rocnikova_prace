using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mach_rocnikova_prace.Models.Person;


namespace Mach_rocnikova_prace.Services
{
    public class PersonDataService : IDataService<Person>
    {
        private readonly RocnikovkaDbContextFactory _contextFactory;

        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="contextFactory">kontext, ve kterém se nachází objekt</param>
        public PersonDataService(RocnikovkaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// CRUD operace create
        /// </summary>
        /// <param name="entity">objek na vytvoření</param>
        /// <returns>vytvořený objekt</returns>
        public async Task<Person> Create(Person entity)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<Person> createdResult = await context.Set<Person>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        /// <summary>
        /// CRUD operace delete
        /// </summary>
        /// <param name="id">id objektu na smazání</param>
        /// <returns>boolean úspěšnosti</returns>
        public async Task<bool> Delete(int id)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                Person entity = await context.Set<Person>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Person>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        /// <summary>
        /// CRUD operace read podle id
        /// </summary>
        /// <param name="id">id objektu, který chceme získat</param>
        /// <returns>vrácený objekt</returns>
        public async Task<Person> Get(int id)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                Person entity = await context.People.Include(a => a.Team).FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        /// <summary>
        /// CRUD operace read multiple
        /// </summary>
        /// <returns>knihovna vrácených objektů</returns>
        public async Task<IEnumerable<Person>> GetAll()
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Person> entities = await context.People.Include(a => a.Team).ToListAsync();
                return entities;
            }
        }

        /// <summary>
        /// CRUD operace update
        /// </summary>
        /// <param name="id">id upravovaného objektu</param>
        /// <param name="entity">parametry nově upraveného objektu</param>
        /// <returns>upravený objekt</returns>
        public async Task<Person> Update(int id, Person entity)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<Person>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        /*public async Task<Person?> GetPerson(int id, PersonIncludeOptions includes)
        {
            using var context = _contextFactory.CreateDbContext();

            IQueryable<Person> query = context.People;

            if (includes.HasFlag(PersonIncludeOptions.Team))
                query = query.Include(p => p.Team);

            if (includes.HasFlag(PersonIncludeOptions.Residences))
                query = query.Include(p => p.Residences);

            /*if (includes.HasFlag(PersonIncludeOptions.Trainings))
                query = query
                    .Include(p => p.Trainings);   // nebo přes join tabulku

            if (includes.HasFlag(PersonIncludeOptions.Attendances))
                query = query.Include(p => p.Attendances);

            if (includes.HasFlag(PersonIncludeOptions.Excuses))
                query = query.Include(p => p.Excuses);

            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }*/

        /*public async Task<IEnumerable<Person>> GetPeople()
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.People
                    .Include(p => p.Team)
                    .Include(p => p.Role)      // když už tam máš i Role
                    .ToListAsync();
            }
        }

        public Task<Person> Update(int id, Person entity)
        {
            throw new NotImplementedException();
        }*/
    }
}
