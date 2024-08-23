using ECommerceServer.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ECommerceServer.Persistence
{
    public class DesignTimeDbContextFactory :IDesignTimeDbContextFactory<ECommerceAPIDbContext>
    {
        public ECommerceAPIDbContext CreateDbContext(string[] args)
        {
        
            DbContextOptionsBuilder<ECommerceAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }

    }
}
