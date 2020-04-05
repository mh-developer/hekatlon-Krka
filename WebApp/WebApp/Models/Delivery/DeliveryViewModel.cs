using System.Collections.Generic;

namespace WebApp.Models.Delivery
{
    public class DeliveryViewModel : DeliveryInputModel
    {
        public IList<DeliveryDto> DeliveriesInProgress { get; set; }

        public IList<DeliveryDto> DeliveriesRequests { get; set; }

        public CompanyDto DestinationCompanies { get; set; }

        public IList<WarehouseDto> Warehouses { get; set; }

        public IList<DeliveryPointDto> DeliveryPoints { get; set; }

        public string DeliveryEvents { get; set; }
    }
}