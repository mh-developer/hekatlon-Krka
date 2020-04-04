using System;
using WebApp.Domain.Models;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class WarehouseDto : EntityDto<Guid>
    {
        public int? MinCode { get; set; }

        public int? MaxCode { get; set; }

        public Company Company { get; set; }

        public string Name { get; set; }
    }
}