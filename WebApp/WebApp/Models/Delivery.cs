﻿using System;

namespace WebApp.Models
{
    public class Delivery
    {
        public virtual int Code { get; set; }
        public virtual DeliveryPoint DeliveryPoint { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime? DispatchTime { get; set; }
        public virtual DateTime? DeliveryTime { get; set; }
        public virtual DateTime? CreationTime { get; set; }
        public virtual Company SourceCompany { get; set; }
        public virtual Company DestinationCompany { get; set; }
    }
}
