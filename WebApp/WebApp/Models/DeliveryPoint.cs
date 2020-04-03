using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class DeliveryPoint
    {
        public virtual int Id { get; set; }
        public virtual String Name { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
