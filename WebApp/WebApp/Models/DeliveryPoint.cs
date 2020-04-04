using System;

namespace WebApp.Models
{
    public class DeliveryPoint
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
