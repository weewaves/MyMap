namespace MyMap.Common
{
    public class Coordinate 
    {
        public Coordinate(decimal _lat, decimal _lon)
        {
            Latitude = _lat;
            Longitude = _lon;
        }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
