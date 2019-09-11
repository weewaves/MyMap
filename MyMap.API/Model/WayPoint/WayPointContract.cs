using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMap.API.Model.WayPoint
{
    public class WayPointContract
    {
        public WayPointContract()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public string WayPointTypeDescription { get; set; }

        public float? Height { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }
    }
}
