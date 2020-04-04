using System;
using WebApp.Domain.Models;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class DeliveryDto : EntityDto<Guid>
    {
        public int Code { get; set; }

        public DeliveryPoint DeliveryPoint { get; set; }

        public DeliveryStatus Status { get; set; }

        public DateTime? DispatchTime { get; set; }

        public DateTime? DeliveryTime { get; set; }

        public DateTime? CreationTime { get; set; }

        public Company SourceCompany { get; set; }

        public Company DestinationCompany { get; set; }
    }
}