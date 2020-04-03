using System;

namespace WebApp.Models
{
    public interface IHasDeletionTime : ISoftDelete
    {
        DateTime? DeletionTime { get; set; }
    }
}