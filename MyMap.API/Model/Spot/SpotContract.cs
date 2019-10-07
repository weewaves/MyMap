using System;

namespace MyMap.API.Model.Spot
{
    public class SpotContract
    {
        public SpotContract()
        {
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public string SpotDescription { get; set; }

        public float? Height { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }
    }
}
