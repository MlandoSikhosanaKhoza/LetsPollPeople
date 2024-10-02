using Bidvest.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get Repository from UnitOfWork
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;


        /// <summary>
        /// Persist user changes asynchronisly
        /// </summary>
        Task SaveChangesAsync();


        /// <summary>
        /// Persist user changes
        /// </summary>
        void SaveChanges();
    }
}
