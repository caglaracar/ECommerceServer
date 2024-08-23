using ECommerceServer.Domain.Entities.Common;

namespace ECommerceServer.Domain.Entities
{
    public class Customer : BaseEntitiy
    {
        public ICollection<Order> Orders { get; set; }
        public string Name { get; set; }

    }
}
