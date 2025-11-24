using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocnikovka_first.Data
{
    /// <summary>
    /// Rozhraní pro základní CRUD operace
    /// </summary>
    public interface ICrudService
    {
        /// <summary>
        /// Asynchronní funkce pro uložení dat do databáze
        /// </summary>
        /// <typeparam name="T">datový typ</typeparam>
        /// <param name="entity">data</param>
        /// <returns></returns>
        Task CreateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Asynchronní funkce, která načte všechny záznamy daného typu z databáze
        /// </summary>
        /// <typeparam name="T">datový typ</typeparam>
        /// <returns></returns>
        Task<List<T>> ReadAllAsync<T>() where T : class;

        /// <summary>
        /// Načte jeden záznam podle klíče
        /// </summary>
        /// <typeparam name="T">typ</typeparam>
        /// <param name="id">hledané id (Primary Key)</param>
        /// <returns></returns>
        Task<T?> ReadAsync<T>(int id) where T : class;

        /// <summary>
        /// Upraví existující záznam
        /// </summary>
        /// <typeparam name="T">typ</typeparam>
        /// <param name="entity">data</param>
        /// <returns></returns>
        Task UpdateAsync<T>(T entity) where T : class;

        /// <summary>
        /// Smaže záznam
        /// </summary>
        /// <typeparam name="T">typ</typeparam>
        /// <param name="entity">data</param>
        /// <returns></returns>
        Task DeleteAsync<T>(T entity) where T : class;
    }
}
