using System;
using WebApp.Models.Shared;

namespace WebApp.Models
{
    public class UserDto : EntityDto<Guid>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}