using ECommerceServer.Application.Repositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistence.Context;

namespace ECommerceServer.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepositories<Order>, IOrderReadRepository
    {
        public OrderReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
