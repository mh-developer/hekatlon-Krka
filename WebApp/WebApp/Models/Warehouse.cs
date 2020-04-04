using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class Warehouse : Entity<Guid>
    {
        public virtual int MinCode { get; set; }

        public virtual int MaxCode { get; set; }

        public virtual Company Company { get; set; }
    }
}