using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using TestManyToMany.IRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace TestManyToMany.Repo
{
    public class GenericRepo<TModel> : IGenericRepo<TModel> where TModel : class
    {
        protected DbSet<TModel> _dbSet;

        public GenericRepo(AppDbContext context)
        {
            _dbSet = context.Set<TModel>();
        }

        public async Task<List<TModel>> GetAllAsync(
            Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null)
        {
            IQueryable<TModel> query = _dbSet;

            // perform query and filter data
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }


            return await query.AsNoTracking().ToListAsync();
        }

        

        public async Task<TModel?> GetByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public virtual async Task AddAsync(TModel entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IList<TModel> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(TModel entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IList<TModel> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public virtual void Remove(params object[] keyValues)
        {
            TModel entityToDelete = _dbSet.Find(keyValues);
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Remove(TModel entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public void RemoveRange(IList<TModel> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
