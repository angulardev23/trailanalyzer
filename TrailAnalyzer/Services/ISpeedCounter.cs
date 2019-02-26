using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Services;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public interface ISpeedCounter
    {
        double MinimumSpeed(Trail trail);
        double MaxiumumSpeed(Trail trail);
        double AverageSpeed(Trail trail);
        double AverageClimbingSpeed(Trail trail);
        double AverageDescentSpeed(Trail trail);
        double AverageFlatSpeed(Trail trail);
    }
}
