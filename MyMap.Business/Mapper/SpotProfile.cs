using AutoMapper;
using MyMap.Business.Model.Spot;
using MyMap.Domain;

namespace MyMap.Business.Mapper
{
    public class SpotProfile : Profile
    {   
        public SpotProfile()
        {
            CreateMap<Spot, SpotModel>();
            CreateMap<SpotModel, Spot>();
        }
    }
}
