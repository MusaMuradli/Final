using Essence.Core.Entities;
using Essence.DataAccess.Contexts;
using Essence.DataAccess.Repositories.Abstractions;
using Essence.DataAccess.Repositories.Implementations.Generic;

namespace Essence.DataAccess.Repositories.Implementations;

internal class ProductSizeRepository : Repository<ProductSize>, IProductSizeRepository
{
    public ProductSizeRepository(AppDbContext context) : base(context)
    {
    }
}

