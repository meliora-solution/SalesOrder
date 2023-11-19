using AutoMapper;
using DataLayer.Entity;
using ServiceLayer.EF.CustomerService;

namespace ServiceLayer.EF.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}