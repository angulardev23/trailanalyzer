using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public interface ITimeCounter
    {
        double TotalTrackTime(Trail trail);
        double ClimnbingTime(Trail trail);
        double DescentTime(Trail trail);
        double FlatTime(Trail trail);
    }
}
