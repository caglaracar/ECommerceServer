using ECommerceServer.Domain.Entities;
using ECommerceServer.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerceServer.Persistence.Context
{
    public class ECommerceAPIDbContext : DbContext
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        {
            // Add IoC Container
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }    

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas=ChangeTracker.Entries<BaseEntitiy>();
            foreach (var data in datas)
            {
                 _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate=DateTime.UtcNow,
                    EntityState.Modified =>data.Entity.UpdatedDate=DateTime.UtcNow,
                    _=>DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
