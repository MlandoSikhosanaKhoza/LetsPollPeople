﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.DAL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet   = context.Set<TEntity>();
        }

        #region Create
        public virtual TEntity Insert(TEntity entity)
        {
            TEntity addedEntity = _dbSet.Add(entity).Entity;
            return addedEntity;
        }
        #endregion Create

        #region Read
        public virtual TEntity? GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public virtual bool Any()
        {
            return _dbSet.Any();
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }
        public virtual async Task<TEntity?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable<TEntity>();
        }
        #endregion Read

        #region Update
        public virtual bool Update(TEntity entityToUpdate)
        {
            try
            {
                _dbSet.Attach(entityToUpdate);
                _context.Entry(entityToUpdate).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion Update

        #region Delete
        public virtual bool Delete(TEntity entityToDelete)
        {
            try
            {
                if (_context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete);
                }
                _dbSet.Remove(entityToDelete);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteById(object Id)
        {
            try
            {
                TEntity? entityToDelete = GetById(Id);
                if (_context.Entry(entityToDelete!).State == EntityState.Detached)
                {
                    _dbSet.Attach(entityToDelete!);
                }
                _dbSet.Remove(entityToDelete!);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion Delete
    }
}
