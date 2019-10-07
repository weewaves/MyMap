using MyMap.Business.Model.Common;
using System;

namespace MyMap.Business.Model.Spot
{
    public class SpotModel : IBusinessModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
            
        public int Type { get; set; }

        public float? Height { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }
    }
}
