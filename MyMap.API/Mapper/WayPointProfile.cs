using AutoMapper;
using MyMap.API.Model.Spot;
using MyMap.Business.Model.Spot;

namespace MyMap.API.Mapper
{
    public class WayPointProfile : Profile
    {
        public WayPointProfile()
        {
            CreateMap<SpotModel, SpotContract>();
            CreateMap<SpotContract, SpotModel>();
            CreateMap<CreateSpotContract, SpotModel>();
        }
    }
}
