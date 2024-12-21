using Essence.Core.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Essence.DataAccess.Repositories.Abstractions.Generic;

public interface IRepository< T> where T : BaseEntity
{
   Task<T?> GetAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);
   Task<T?> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);
   IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);
   IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);

    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);

}
