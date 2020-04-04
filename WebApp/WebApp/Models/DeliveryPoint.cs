using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class DeliveryPoint : Entity<Guid>
    {
        public virtual string Name { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}