using System;

namespace WebApp.Domain.Models.Shared
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletionTime { get; set; }
    }
}