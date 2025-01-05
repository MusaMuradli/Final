using Essence.Core.Entities;
using Essence.DataAccess.Contexts;
using Essence.DataAccess.Repositories.Abstractions;
using Essence.DataAccess.Repositories.Implementations.Generic;

namespace Essence.DataAccess.Repositories.Implementations;

internal class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
