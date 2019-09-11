using AutoMapper;
using MyMap.Business.Model.WayPoint;
using MyMap.Domain;

namespace MyMap.Business.Mapper
{
    public class WayPointProfile : Profile
    {
        public WayPointProfile()
        {
            CreateMap<WayPoint, WayPointModel>();
            CreateMap<WayPointModel, WayPoint>();
        }
    }
}
