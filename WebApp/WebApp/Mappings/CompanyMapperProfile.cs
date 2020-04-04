using AutoMapper;
using WebApp.Domain.Models;
using WebApp.Models;

namespace WebApp.Mappings
{
    public class CompanyMapperProfile : Profile
    {
        public CompanyMapperProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
        }
    }
}