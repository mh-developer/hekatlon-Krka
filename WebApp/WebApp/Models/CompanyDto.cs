using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class CompanyDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}