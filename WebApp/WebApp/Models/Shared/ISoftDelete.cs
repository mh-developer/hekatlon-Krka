﻿namespace WebApp.Models
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
