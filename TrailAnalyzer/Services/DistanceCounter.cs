using System.Linq;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public class DistanceCounter : ListOperations, IDistanceCounter
    {
        public double TotalDistance(Trail trail)
        {
            return trail.Points.Select((point, i) => PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point))).Sum();
        }

        public double ClimbingDistance(Trail trail)
        {
            return trail.Points
                .Select((point, i) => GetNext(trail.Points, point)?.Elevation - point.Elevation > 0 ?
                    PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) : 0)
                .Sum();
        }

        public double DescentDistance(Trail trail)
        {
            return trail.Points
                .Select((point, i) => point.Elevation - GetNext(trail.Points, point)?.Elevation > 0 ?
                    PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) : 0)
                .Sum();
        }

        public double FlatDistance(Trail trail)
        {
            return trail.Points
                .Select((point, i) => point.Elevation - GetNext(trail.Points, point)?.Elevation == 0 ?
                    PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) : 0)
                .Sum();
        }
    }
}
