using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Domain.Models
{
    public class Event
    {
        public virtual string Title { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }
    }
}
