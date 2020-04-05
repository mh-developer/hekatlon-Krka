using System.Collections.Generic;

namespace WebApp.Models.Warehouses
{
    public class WarehouseViewModel : WarehouseDto
    {
        public IList<WarehouseDto> Warehouses { get; set; }

        public IList<DeliveryPointDto> DeliveryPoints { get; set; }
    }
}