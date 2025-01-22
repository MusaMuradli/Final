using Essence.Core.Entities;
using Essence.DataAccess.Contexts;
using Essence.DataAccess.Repositories.Abstractions;
using Essence.DataAccess.Repositories.Implementations.Generic;

namespace Essence.DataAccess.Repositories.Implementations;

internal class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
{
    public BasketItemRepository(AppDbContext context) : base(context)
    {
    }
}
