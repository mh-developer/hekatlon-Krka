using System;

namespace WebApp.Models
{
    public class Event
    {
        public virtual string title { get; set; }

        public virtual DateTime? start { get; set; }

        public virtual DateTime? end { get; set; }
    }
}