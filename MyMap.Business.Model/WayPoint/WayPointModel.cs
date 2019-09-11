using MyMap.Business.Model.Common;
using System;

namespace MyMap.Business.Model.WayPoint
{
    public enum WaypointTypeEnum
    {
        PEAK = 1,
        PASS = 2,
        HUT = 3,
        VILLAGE = 4,
        LAKE = 5,
        PUB_TRANS = 6,
        CAVE = 7,
        GLACIER = 8,
        WATERFALL = 9,
        OTHER = 100
    }

    public class WayPointModel : IBusinessModel
    {
        public Guid Id { get; set; }

        public Guid CreatedByUserId { get; set; }

        public string DescriptiveKey { get; set; }

        public string Name { get; set; }

        public WaypointTypeEnum Type { get; set; }

        public float? Height { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public int ReportCount { get; set; }

        public string SourceKey { get; set; }

        public int PictureCount { get; set; }
    }
}
