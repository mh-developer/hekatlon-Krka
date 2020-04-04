using AutoMapper;
using WebApp.Domain.Models;
using WebApp.Models;

namespace WebApp.Mappings
{
    public class WarehouseMapperProfile : Profile
    {
        public WarehouseMapperProfile()
        {
            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<WarehouseDto, Warehouse>();
        }
    }
}