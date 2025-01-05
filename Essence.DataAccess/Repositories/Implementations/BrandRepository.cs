using Essence.Core.Entities;
using Essence.DataAccess.Contexts;
using Essence.DataAccess.Repositories.Abstractions;
using Essence.DataAccess.Repositories.Implementations.Generic;

namespace Essence.DataAccess.Repositories.Implementations;

internal class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(AppDbContext context) : base(context)
    {
    }
}