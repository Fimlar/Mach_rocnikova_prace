using Mach_rocnikova_prace.Data;
using Mach_rocnikova_prace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach_rocnikova_prace.Services
{
    /// <summary>
    /// CRUD Operace pro generický typ dat
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly RocnikovkaDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="contextFactory">kontext, ve kterém se nachází objekt</param>
        public GenericDataService(RocnikovkaDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        /// <summary>
        /// volání funkce Create přes _nonQueryDataService
        /// </summary>
        /// <param name="entity">objek na vytvoření</param>
        /// <returns>vytvořený objekt</returns>
        public async Task<T> Create(T entity)
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
        public async Task<T> GetById(int id)
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
        /// volání funkce Update přes _nonQueryDataService
        /// </summary>
        /// <param name="id">id upravovaného objektu</param>
        /// <param name="entity">parametry nově upraveného objektu</param>
        /// <returns>upravený objekt</returns>
        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
