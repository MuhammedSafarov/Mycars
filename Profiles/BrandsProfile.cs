using AutoMapper;
using Mycars.Dtos;
using Mycars.Models;

namespace Mycars.Profiles
{
    public class BrandsProfile : Profile
    {
        public BrandsProfile()
        {
            //Source -> Target
            CreateMap<Brands, BrandReadDto>();
            CreateMap<BrandCreateDto, Brands>();
            CreateMap<BrandUpdateDto, Brands>();
            CreateMap<Brands, BrandUpdateDto>();

        }

    }
    
}