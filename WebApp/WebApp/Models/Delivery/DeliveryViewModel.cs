using System.Collections.Generic;

namespace WebApp.Models.Delivery
{
    public class DeliveryViewModel : DeliveryInputModel
    {
        public IList<DeliveryDto> DeliveryDtos { get; set; }
    }
}