using System;

namespace WebApp.Domain.Models.Shared
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>, IHasDeletionTime
    {
        public virtual TPrimaryKey Id { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime? DeletionTime { get; set; }
    }
}
