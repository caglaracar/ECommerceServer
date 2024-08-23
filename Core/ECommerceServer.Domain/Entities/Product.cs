using ECommerceServer.Domain.Entities.Common;

namespace ECommerceServer.Domain.Entities
{
    public class Product : BaseEntitiy
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public ICollection<Order> Orders { get; set; }      


    }
}
