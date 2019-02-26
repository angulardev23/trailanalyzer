using System;
using System.Linq;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public class TimeCounter :ListOperations, ITimeCounter
    {
        public double TotalTrackTime(Trail trail)
        {
            return (trail.Points.Max(point => point.Time) - trail.Points.Min(point => point.Time)).Seconds;
        }

        public double ClimnbingTime(Trail trail)
        {
            return trail.Points
                .Select((point, i) => GetNext(trail.Points, point).Elevation - point.Elevation > 0 ?
                    (GetNext(trail.Points, point).Time - point.Time) : TimeSpan.FromSeconds(0))
                .Sum(r => r.Seconds);
        }

        public double DescentTime(Trail trail)
        {
            return trail.Points
                .Select((point, i) =>point.Elevation - GetNext(trail.Points, point).Elevation > 0 ?
                    (GetNext(trail.Points, point).Time - point.Time) : new TimeSpan(0))
                .Sum(r => r.Seconds);
        }

        public double FlatTime(Trail trail)
        {
            return trail.Points
                .Select((point, i) =>point.Elevation - GetNext(trail.Points, point).Elevation == 0 ?
                    (GetNext(trail.Points, point).Time - point.Time) : new TimeSpan(0))
                .Sum(r => r.Seconds);
        }
    }
}
