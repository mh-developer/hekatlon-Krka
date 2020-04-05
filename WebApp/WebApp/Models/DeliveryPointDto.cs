using System;
using WebApp.Domain.Models;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class DeliveryPointDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public Warehouse Warehouse { get; set; }

        public Guid? WarehouseId { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}