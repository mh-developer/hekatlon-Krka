using System;
using WebApp.Domain.Models.Shared;

namespace WebApp.Domain.Models
{
    public class DeliveryPoint : Entity<Guid>
    {
        public virtual string Name { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Guid? WarehouseId { get; set; }

        public virtual string Address { get; set; }

        public virtual string PhoneNumber { get; set; }
    }
}