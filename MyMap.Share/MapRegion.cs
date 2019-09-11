using System;

namespace MyMap.Common
{
    /// <summary>
    /// TopLeft      ===========================     TopRi  ght
    ///              =                         =
    ///              =                         =
    /// BottomLeft   ===========================     BottomRight
    /// </summary>
    public class MapRegion
    {
        private decimal baseLatitude = Convert.ToDecimal(0);
        private decimal maxLatitude = Convert.ToDecimal(90);
        private decimal minLatitude = Convert.ToDecimal(-90);

        private decimal baseLongitude = Convert.ToDecimal(0);
        private decimal maxLongitude = Convert.ToDecimal(180);
        private decimal minLongitude = Convert.ToDecimal(-180);

        public Coordinate TopRightCorner { get; set; }
        public Coordinate BottomRightCorner { get; set; }
        public Coordinate BottomLeftCorner { get; set; }
        public Coordinate TopLeftCorner { get; set; }

        /// <summary>
        /// Has at least 2 coordinates lies on the same diagonal line
        /// </summary>
        /// <returns></returns>
        public bool IsValidRegion()
        {
            return (TopLeftCorner != null && BottomRightCorner != null)
                || (TopRightCorner != null && BottomLeftCorner != null);
        }

        /// <summary>
        /// Check if a location lies inside a region
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public bool Contains(Coordinate coordinate)
        {
            // Extract Latitude - Closest to the North
            var topLatitude = TopLeftCorner != null ? TopLeftCorner.Latitude : TopRightCorner.Latitude;
            var bottomLatitude = BottomLeftCorner != null ? BottomLeftCorner.Latitude : BottomRightCorner.Latitude;

            // Extract longitude - Closest to the South
            var leftLongitude = TopLeftCorner != null ? TopLeftCorner.Longitude : BottomLeftCorner.Longitude;
            var rightLongitude = TopRightCorner != null ? TopRightCorner.Longitude : BottomRightCorner.Longitude;

            return IsGivenLatitudeValid(coordinate.Latitude, bottomLatitude, topLatitude)
                && IsGivenLongitudeValid(coordinate.Longitude, leftLongitude, rightLongitude);
        }

        public decimal GetMinLatitude()
        {
            if (TopRightCorner == null && BottomLeftCorner == null)
            {
                return minLatitude;
            }

            return Math.Min(TopRightCorner?.Latitude ?? maxLatitude, BottomLeftCorner?.Latitude ?? maxLatitude);
        }

        public decimal GetMinLongitude()
        {
            if (TopRightCorner == null && BottomLeftCorner == null)
            {
                return minLongitude;
            }

            return Math.Min(TopRightCorner?.Longitude ?? maxLongitude, BottomLeftCorner?.Longitude ?? maxLongitude);
        }

        public decimal GetMaxLatitude()
        {
            if (TopRightCorner == null && BottomLeftCorner == null)
            {
                return maxLongitude;
            }

            return Math.Max(TopRightCorner?.Latitude ?? minLatitude, BottomLeftCorner?.Latitude ?? minLatitude);
        }

        public decimal GetMaxLongitude()
        {
            if (TopRightCorner == null && BottomLeftCorner == null)
            {
                return maxLongitude;
            }

            return Math.Max(TopRightCorner?.Longitude ?? minLongitude, BottomLeftCorner?.Longitude ?? minLongitude);
        }

        private bool IsGivenLatitudeValid(decimal value, decimal bottomLatitude, decimal topLatitude)
        {
            return bottomLatitude <= value && value <= topLatitude;
        }

        private bool IsGivenLongitudeValid(decimal value, decimal leftLongitude, decimal rightLongitude)
        {
            // Left longitude is positive (0 -> +180) while right longitude is negative (-180 -> 0)
            if ((minLongitude <= rightLongitude && rightLongitude <= baseLongitude)
                && (baseLongitude <= leftLongitude && leftLongitude <= maxLongitude))
            {
                return rightLongitude <= value && value <= leftLongitude;
            }

            return leftLongitude <= value && value <= rightLongitude; ;
        }
    }
}
