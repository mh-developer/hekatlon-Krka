using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class CompanyDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}