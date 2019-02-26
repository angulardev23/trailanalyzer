using System.Linq;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public class SpeedCounter : ListOperations, ISpeedCounter
    {
        public double MinimumSpeed(Trail trail)
        {
            return trail.Points
                .Select((point, i) => PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) /
                                  (GetNext(trail.Points, point).Time - point.Time).TotalSeconds)
                .Min();
        }

        public double MaxiumumSpeed(Trail trail)
        {
            return trail.Points
                .Select((point, i) => PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) /
                                  (GetNext(trail.Points, point).Time - point.Time).TotalSeconds)
                .Max();
        }

        public double AverageSpeed(Trail trail)
        {
            return trail.Points
                .Select((point, i) => PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) /
                                  (GetNext(trail.Points, point).Time - point.Time).TotalSeconds)
                .Average();
        }

        public double AverageClimbingSpeed(Trail trail)
        {
            return trail.Points
                .Select((point, i) => (GetNext(trail.Points, point).Elevation - point.Elevation > 0 ?
                                      PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) : 0) /
                                  (GetNext(trail.Points, point).Time - point.Time).TotalSeconds)
                .Where(s => s != 0)
                .Average();
        }

        public double AverageDescentSpeed(Trail trail)
        {
            return trail.Points
                .Select((point, i) => (point.Elevation - GetNext(trail.Points, point).Elevation > 0 ?
                                      PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) : 0) /
                                  (GetNext(trail.Points, point).Time - point.Time).TotalSeconds)
                .Where(s => s != 0)
                .Average();
        }

        public double AverageFlatSpeed(Trail trail)
        {
            return trail.Points
                .Select((point, i) => (point.Elevation - GetNext(trail.Points, point).Elevation == 0 ?
                                      PointService.DistanceBeetwenPoints(point, GetNext(trail.Points, point)) : 0) /
                                  (GetNext(trail.Points, point).Time - point.Time).TotalSeconds)
                .Where(s => s != 0)
                .Average();
        }
    }
}
