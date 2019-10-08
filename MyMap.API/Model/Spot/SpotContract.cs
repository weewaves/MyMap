using System;
using System.Collections.Generic;

namespace MyMap.API.Model.Spot
{
    public class SpotContract
    {
        public Guid Id { get; set; }

        public string SpotDescription { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public int? Vote { get; set; }

        public string[] PictureUrls { get; set; }

        public float? Height { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public Guid? AreaId { get; set; }
    }
}
