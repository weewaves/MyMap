using MyMap.DataModel.Domain;

namespace MyMap.Domain
{
    public class WayPoint: DomainBase
    {
        public string Name { get; set; }

        public int Type { get; set; }

        public float? Height { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }
    }   
}
