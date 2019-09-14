namespace MyMap.Common
{
    public class Coordinate 
    {
        public Coordinate(decimal _lat, decimal _lon)
        {
            Lat = _lat;
            Lng = _lon;
        }

        public decimal Lat { get; set; }

        public decimal Lng { get; set; }
    }
}
