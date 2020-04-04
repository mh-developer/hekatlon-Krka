using System;
using WebApp.Domain.Models.Shared;

namespace WebApp.Domain.Models
{
    public class Warehouse : Entity<Guid>
    {
        public virtual int? MinCode { get; set; }

        public virtual int? MaxCode { get; set; }

        public virtual Company Company { get; set; }

        public virtual string Name { get; set; }
    }
}