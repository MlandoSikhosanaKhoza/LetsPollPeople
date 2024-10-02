using Bidvest.DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<Type, object> Repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Repository from UnitOfWork
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (this.Repositories == null)
            {
                this.Repositories = new Dictionary<Type, object>();
            }
            var type = typeof(TEntity);
            if (!this.Repositories.ContainsKey(type))
            {
                this.Repositories[type] = new GenericRepository<TEntity>(this._context);
            }

            return (GenericRepository<TEntity>)this.Repositories[type];
        }

        /// <summary>
        /// Persist user changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Persist user changes asynchronisly
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Dispose tracking data
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
