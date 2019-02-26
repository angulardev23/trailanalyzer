using System;
using System.Collections.Generic;
using System.Text;
using TrailAnalyzer.Models;

namespace TrailAnalyzer.Services
{
    public interface IGpxService
    {
        Trail CreateTrail(string gpxContent);
        string GetTrailBody();
    }
}
