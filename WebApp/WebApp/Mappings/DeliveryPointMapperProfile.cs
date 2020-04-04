using AutoMapper;
using WebApp.Domain.Models;
using WebApp.Models;

namespace WebApp.Mappings
{
    public class DeliveryPointMapperProfile : Profile
    {
        public DeliveryPointMapperProfile()
        {
            CreateMap<DeliveryPoint, DeliveryPointDto>();
            CreateMap<DeliveryPointDto, DeliveryPoint>();
        }
    }
}