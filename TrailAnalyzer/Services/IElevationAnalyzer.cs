using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public interface IElevationCounter
    {
        double MinimalElevation(Trail trail);
        double MaximumElevation(Trail trail);
        double AverageElevation(Trail trail);
        double TotalClimbing(Trail trail);
        double TotalDescent(Trail trail);
        double FinalBalance(Trail trail);
    }
}
