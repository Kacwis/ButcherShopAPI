using AutoMapper;
using ButcherShop.Models;
using ButcherShop.Models.DTO;

namespace ButcherShop
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Customer, CustomerCreateDTO>().ReverseMap();
        }
    }
}
