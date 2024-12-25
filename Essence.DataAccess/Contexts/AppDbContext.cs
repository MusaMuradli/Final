using Essence.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Essence.DataAccess.Contexts;

public class AppDbContext: IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

}
