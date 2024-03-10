
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestManyToMany.IRepo
{
    public interface IGenericRepo<TModel> where TModel : class
    {
        Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>> filter = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
            Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>>? include = null);
        
        Task<TModel?> GetByIdAsync(params object[] keyValues);

        Task AddAsync(TModel entity);
        Task AddRangeAsync(IList<TModel> entities);

        void Update(TModel entity);

        void UpdateRange(IList<TModel> entities);

        void RemoveRange(IList<TModel> entities);

    }
}
