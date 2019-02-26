using System;
using System.Collections.Generic;
using System.Text;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public interface IDistanceCounter
    {
        double TotalDistance(Trail trail);
        double ClimbingDistance(Trail trail);
        double DescentDistance(Trail trail);
        double FlatDistance(Trail trail);
    }
}
