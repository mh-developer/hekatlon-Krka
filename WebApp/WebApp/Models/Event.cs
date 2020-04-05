using System;

namespace WebApp.Models
{
    public class Event
    {
        public virtual string Title { get; set; }

        public virtual DateTime? Start { get; set; }

        public virtual DateTime? End { get; set; }
    }
}