using AutoMapper;
using MyMap.API.Model.WayPoint;
using MyMap.Business.Model.WayPoint;

namespace MyMap.API.Mapper
{
    public class WayPointProfile : Profile
    {
        public WayPointProfile()
        {
            CreateMap<WayPointModel, WayPointContract>()
                                        .ForMember(o => o.WayPointTypeDescription, src => src.MapFrom(o => o.Type.ToString()));
            CreateMap<WayPointContract, WayPointModel>()
                                        .ForMember(o => o.Type, src => src.MapFrom(o => (WaypointTypeEnum)o.Type));
        }
    }
}
