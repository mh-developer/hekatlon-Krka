using System;

namespace WebApp.Models.Shared
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletionTime { get; set; }
    }
}