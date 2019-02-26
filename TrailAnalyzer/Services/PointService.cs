using System;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public static class PointService
    {
        private readonly static int EarthRadius = 6371; 
        public static double DistanceBeetwenPoints(Point startPoint, Point endPoint)
        {
            if (startPoint == null || endPoint == null) return 0;

            var latitude = (endPoint.Latitude - startPoint.Latitude).DegreesToRadians();
            var longtitude = (endPoint.Longitude - startPoint.Longitude).DegreesToRadians();

            var startHeight = Math.Sin(latitude / 2) * Math.Sin(latitude / 2) +
                     Math.Cos(startPoint.Latitude.DegreesToRadians()) * Math.Cos(endPoint.Latitude.DegreesToRadians()) *
                     Math.Sin(longtitude / 2) * Math.Sin(longtitude / 2);

            var endHeight = 2 * Math.Asin(Math.Min(1, Math.Sqrt(startHeight)));

            return EarthRadius * endHeight;
        }

        public static double DegreesToRadians(this double degreesValue)
        {
            return (Math.PI / 180) * degreesValue;
        }
    }
}
