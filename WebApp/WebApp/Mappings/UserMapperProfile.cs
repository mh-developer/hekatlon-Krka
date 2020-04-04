using AutoMapper;
using WebApp.Models;

namespace WebApp.Mappings
{
    public class UserMapperProfile: Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
