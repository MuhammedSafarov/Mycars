using AutoMapper;
using Mycars.Dtos;
using Mycars.Models;

namespace Mycars.Profiles
{
    public class FeaturesProfile : Profile
    {
        public FeaturesProfile()
        {
            CreateMap<Features, FeatureReadDto>();
            CreateMap<FeatureCreateDto, Features>();
            CreateMap<FeatureUpdateDto, Features>();
            CreateMap<Features, FeatureUpdateDto>();

        }
    }
}
