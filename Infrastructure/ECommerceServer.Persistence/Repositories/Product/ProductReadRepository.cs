using ECommerceServer.Application.Repositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistence.Context;

namespace ECommerceServer.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepositories<Product>, IProductReadRepository
    {
        public ProductReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
