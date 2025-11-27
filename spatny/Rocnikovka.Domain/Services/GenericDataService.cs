using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rocnikovka.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace Rocnikovka.Domain.Services
{
    /// <summary>
    /// CRUD Operations definitions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly RocnikovkaDbContextFactory _contextFactory;

        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="contextFactory">kontext, ve kterém se nachází objekt</param>
        public GenericDataService(RocnikovkaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// CRUD operace create
        /// </summary>
        /// <param name="entity">objek na vytvoření</param>
        /// <returns>vytvořený objekt</returns>
        public async Task<T> Create(T entity)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
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
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        /// <summary>
        /// CRUD operace read podle id
        /// </summary>
        /// <param name="id">id objektu, který chceme získat</param>
        /// <returns>vrácený objekt</returns>
        public async Task<T> Get(int id)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        /// <summary>
        /// CRUD operace read multiple
        /// </summary>
        /// <returns>knihovna vrácených objektů</returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        /// <summary>
        /// CRUD operace update
        /// </summary>
        /// <param name="id">id upravovaného objektu</param>
        /// <param name="entity">parametry nově upraveného objektu</param>
        /// <returns>upravený objekt</returns>
        public async Task<T> Update(int id, T entity)
        {
            using (RocnikovkaDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
*/