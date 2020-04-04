﻿using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class Delivery : Entity<Guid>
    {
        public virtual int Code { get; set; }

        public virtual DeliveryPoint DeliveryPoint { get; set; }

        public virtual DeliveryStatus Status { get; set; }

        public virtual DateTime? DispatchTime { get; set; }

        public virtual DateTime? DeliveryTime { get; set; }

        public virtual DateTime? CreationTime { get; set; }

        public virtual Company SourceCompany { get; set; }

        public virtual Company DestinationCompany { get; set; }
    }

    public enum DeliveryStatus
    {
        None = 0,
        InProgress = 1,
        Received = 2
    }
}