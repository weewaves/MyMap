using AutoMapper;
using MyMap.API.Model.WayPoint;
using MyMap.Business.Model.WayPoint;

namespace MyMap.API.Mapper
{
    public class WayPointProfile : Profile
    {
        public WayPointProfile()
        {
            CreateMap<WayPointModel, WayPointContract>();
            CreateMap<WayPointContract, WayPointModel>();
            CreateMap<CreateWayPointContract, WayPointModel>();
        }
    }
}
