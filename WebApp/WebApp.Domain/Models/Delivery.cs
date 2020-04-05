using System;
using WebApp.Domain.Models.Shared;

namespace WebApp.Domain.Models
{
    public class Delivery : Entity<Guid>
    {
        public virtual int Code { get; set; }

        public virtual DeliveryPoint DeliveryPoint { get; set; }
        
        public virtual Guid? DeliveryPointId { get; set; }

        public virtual DeliveryStatus Status { get; set; }

        public virtual DateTime? DispatchTime { get; set; }

        public virtual DateTime? DeliveryTime { get; set; }

        public virtual DateTime? CreationTime { get; set; }

        public virtual Company SourceCompany { get; set; }

        public virtual Guid? SourceCompanyId { get; set; }

        public virtual Company DestinationCompany { get; set; }

        public virtual Guid? DestinationCompanyId { get; set; }
    }

    public enum DeliveryStatus
    {
        None = 0,
        InProgress = 1,
        Rejected = 2,
        Received = 3
    }
}