using System;
using WebApp.Domain.Models.Shared;

namespace WebApp.Domain.Models
{
    public class Company : Entity<Guid>
    {
        public virtual string Name { get; set; }
    }
}