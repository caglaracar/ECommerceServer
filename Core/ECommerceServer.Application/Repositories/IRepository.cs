using ECommerceServer.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace ECommerceServer.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntitiy
    {
        DbSet<T> Table { get; }
    }
}
