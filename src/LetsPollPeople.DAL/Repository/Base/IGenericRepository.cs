using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LetsPollPeople.DAL.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //TODO: Add Comments
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        //TODO: Add Comments
        TEntity? GetById(object id);
        //TODO: Add Comments
        Task<TEntity?> GetByIdAsync(object id);
        //TODO: Add Comments
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        //TODO: Add Comments
        Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        //TODO: Add Comments
        bool Any();

        //TODO: Add Comments
        int Count();
        TEntity Insert(TEntity entity);

        //TODO: Add Comments
        bool Update(TEntity entity);

        //TODO: Add Comments
        bool Delete(TEntity entity);

    }
}
