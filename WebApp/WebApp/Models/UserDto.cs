using System;
using WebApp.Domain.Models;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class UserDto : EntityDto<Guid>
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Company Company { get; set; }
        
        public Guid? CompanyId { get; set; }

        public Warehouse Warehouse { get; set; }
        
        public Guid? WarehouseId { get; set; }
    }
}