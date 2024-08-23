using ECommerceServer.Application.Repositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistence.Context;

namespace ECommerceServer.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
