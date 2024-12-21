using Essence.Core.Entities.Common;
using Essence.DataAccess.Contexts;
using Essence.DataAccess.Repositories.Abstractions.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Essence.DataAccess.Repositories.Implementations.Generic;

internal abstract class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private DbSet<T> _table;

    public Repository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
