using ECommerceServer.Application.Repositories;
using ECommerceServer.Domain.Entities;
using ECommerceServer.Persistence.Context;

namespace ECommerceServer.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepositories<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ECommerceAPIDbContext context) : base(context)
        {
        }
    }
}
