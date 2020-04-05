using System;
using WebApp.Domain.Models.Shared;

namespace WebApp.Domain.Models
{
    public class Warehouse : Entity<Guid>
    {
        public virtual int? MinCode { get; set; }

        public virtual int? MaxCode { get; set; }

        public virtual Company Company { get; set; }
        
        public virtual Guid? CompanyId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string PhoneNumber { get; set; }
    }
}