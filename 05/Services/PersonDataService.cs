using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Mach_rocnikova_prace.Models.Person;


namespace Mach_rocnikova_prace.Services
{
    /// <summary>
    /// CRUD operace pro získávání lidí
    /// </summary>
    public class PersonDataService : IDataService<Person>
    {
        private readonly NonQueryDataService<Person> _nonQueryDataService;
        private readonly RocnikovkaDbContextFactory _contextFactory;

        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="contextFactory">kontext, ve kterém se nachází objekt</param>
        public PersonDataService(RocnikovkaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Person>(contextFactory);
        }

        /// <summary>
        /// volání funkce Create přes _nonQueryDataService
        /// </summary>
        /// <param name="entity">objek na vytvoření</param>
        /// <returns>vytvořený objekt</returns>
        public async Task<Person> Create(Person entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        /// <summary>
        /// volání funkce Delete přes _nonQueryDataService
        /// </summary>
        /// <param name="id">id objektu na smazání</param>
        /// <returns>boolean úspěšnosti</returns>
        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        /// <summary>
        /// CRUD operace read podle id
        /// </summary>
        /// <param name="id">id objektu, který chceme získat</param>
        /// <returns>vrácený objekt</returns>
        public async Task<Person> GetById(int id)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                // díky Include můžeme získat data i z jiných tabulek
                Person entity = await context.People.Include(a => a.Team).Include(a => a.Role).FirstOrDefaultAsync((e) => e.Id == id);

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
                IEnumerable<Person> entities = await context.People.Include(a => a.Team).Include(a => a.Role).ToListAsync();
                return entities;
            }
        }

        /// <summary>
        /// volání funkce Update přes _nonQueryDataService
        /// </summary>
        /// <param name="id">id upravovaného objektu</param>
        /// <param name="entity">parametry nově upraveného objektu</param>
        /// <returns>upravený objekt</returns>
        public async Task<Person> Update(int id, Person updatedPerson)
        {
            // return await _nonQueryDataService.Update(id, entity);
            using var context = _contextFactory.CreateDbContext();

            var existingPerson = await context.People
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPerson is null)
                throw new InvalidOperationException($"Person with id {id} not found.");

            // Přepíšeme scalar properties
            existingPerson.FirstName = updatedPerson.FirstName;
            existingPerson.LastName = updatedPerson.LastName;
            existingPerson.DateOfBirth = updatedPerson.DateOfBirth;
            existingPerson.BirthNumber = updatedPerson.BirthNumber;
            existingPerson.InsuranceCompanyName = updatedPerson.InsuranceCompanyName;
            existingPerson.InsuranceCompanyId = updatedPerson.InsuranceCompanyId;
            existingPerson.City = updatedPerson.City;
            existingPerson.StreetName = updatedPerson.StreetName;
            existingPerson.PostalNumber = updatedPerson.PostalNumber;
            existingPerson.PostalCode = updatedPerson.PostalCode;
            existingPerson.TeamId = updatedPerson.TeamId;
            existingPerson.RoleId = updatedPerson.RoleId;
            // ...doplň další sloupce, které chceš, aby šly upravovat

            // Navigace buď necháš na EF (jen FK), nebo:
            // existingPerson.Team = null;
            // existingPerson.Role = null;
            // (není nutné, pokud jen měníš FK)

            await context.SaveChangesAsync();

            return existingPerson;
        }

        /// <summary>
        /// funkce pro získání všech členů s konkrétním roleId
        /// </summary>
        /// <param name="roleId">Id hledané role</param>
        /// <returns>proměnná všech lidí s danou rolí</returns>
        public async Task<IEnumerable<Person>> GetByRoleId(string roleId)
        {
            // Pokus o převod na int
            if (!int.TryParse(roleId, out int id))
            {
                // pokud převod selže, vracíme prázdnou kolekci
                return Enumerable.Empty<Person>();
            }
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                // získáme všechny osoby s daným RoleId
                var people = await context.People
                    .Include(p => p.Team)
                    .Include(p => p.Role)
                    .Where(p => p.RoleId == id)
                    .ToListAsync();

                return people;
            }
        }

        /// <summary>
        /// funkce pro získání všech členů s konkrétním teamId
        /// </summary>
        /// <param name="teamId">Id hledaného týmu</param>
        /// <returns>proměnná všech lidí z daného týmu</returns>
        public async Task<IEnumerable<Person>> GetByTeamId(string teamId)
        {
            // Pokus o převod na int
            if (!int.TryParse(teamId, out int id))
            {
                // pokud převod selže, vracíme prázdnou kolekci
                return Enumerable.Empty<Person>();
            }
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                // získáme všechny osoby s daným RoleId
                var people = await context.People
                    .Include(p => p.Team)
                    .Include(p => p.Role)
                    .Where(p => p.TeamId == id)
                    .ToListAsync();

                return people;
            }
        }

        public async Task<IEnumerable<Person>> GetByInsuranceId(string insuranceId)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                // získáme všechny osoby s daným RoleId
                var people = await context.People
                    .Include(p => p.Team)
                    .Include(p => p.Role)
                    .Where(p => p.InsuranceCompanyId == insuranceId)
                    .ToListAsync();

                return people;
            }
        }

        public async Task<IEnumerable<Person>> GetByLastName(string lastName)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                // získáme všechny osoby s daným RoleId
                var people = await context.People
                    .Include(p => p.Team)
                    .Include(p => p.Role)
                    .Where(p => p.LastName == lastName)
                    .ToListAsync();

                return people;
            }
        }

    }
}
