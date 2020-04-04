using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class Company : Entity<Guid>
    {
        public virtual string Name { get; set; }
    }
}