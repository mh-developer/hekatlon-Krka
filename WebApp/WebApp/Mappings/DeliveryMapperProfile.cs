using AutoMapper;
using WebApp.Domain.Models;
using WebApp.Models;

namespace WebApp.Mappings
{
    public class DeliveryMapperProfile : Profile
    {
        public DeliveryMapperProfile()
        {
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryDto, Delivery>();
        }
    }
}