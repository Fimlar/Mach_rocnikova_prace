using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka_first.Data
{
    /// <summary>
    /// Implementace generické CRUD služby nad RocnikovkaContext.
    /// </summary>
    public class CrudService : ICrudService
    {
        private readonly RocnikovkaContext _context;

        /// <summary>
        /// Konstruktor, který přijme DbContext.
        /// </summary>
        public CrudService(RocnikovkaContext context)
        {
            _context = context;
        }

        // Volání metod z rozhranní
        public async Task CreateAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<List<T>> ReadAllAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> ReadAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
