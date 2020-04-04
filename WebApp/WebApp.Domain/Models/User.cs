using Microsoft.AspNetCore.Identity;
using System;
using WebApp.Domain.Models.Shared;

namespace WebApp.Domain.Models
{
    public class User : IdentityUser<Guid>, IEntity<Guid>, IHasDeletionTime
    {
        public virtual bool IsDeleted { get; set; }

        public virtual DateTime? DeletionTime { get; set; }

        public virtual Company Company { get; set; }
    }
}