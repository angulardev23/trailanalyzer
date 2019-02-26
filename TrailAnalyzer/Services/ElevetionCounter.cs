using System.Linq;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public class ElevetionCounter : ListOperations, IElevationCounter
    {
        public double MinimalElevation(Trail trail)
        {
            return trail.Points.Min(point => point.Elevation);
        }

        public double MaximumElevation(Trail trail)
        {
            return trail.Points.Max(point => point.Elevation);
        }

        public double AverageElevation(Trail trail)
        {
            return trail.Points.Average(point => point.Elevation);
        }

        public double TotalClimbing(Trail trail)
        {
            return trail.Points
                .Select((point, i) => GetNext(trail.Points, point).Elevation - point.Elevation)
                .Where(e => e > 0)
                .Sum();
        }

        public double TotalDescent(Trail trail)
        {
            return trail.Points
                .Select((point, i) => point.Elevation - GetNext(trail.Points, point).Elevation)
                .Where(e => e > 0)
                .Sum();
        }

        public double FinalBalance(Trail trail)
        {
            return TotalClimbing(trail) - TotalDescent(trail);
        }
    }
}
