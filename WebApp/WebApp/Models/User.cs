using Microsoft.AspNetCore.Identity;
using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class User : IdentityUser<Guid>, IEntity<Guid>
    {
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime? DeletionTime { get; set; }
    }
}