using Microsoft.Extensions.DependencyInjection;
using System;
using TrailAnalyzer.Services;

namespace Startup
{
    class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var serviceProvider = ContainerConfig.ConfigureContainers(services);

            var _distanceCounter = serviceProvider.GetService<IDistanceCounter>();
            var _gpxService = serviceProvider.GetService<IGpxService>();

            var trail = _gpxService.CreateTrail(_gpxService.GetTrailBody());

            //distance counting
            var climbingDistance = _distanceCounter.ClimbingDistance(trail);
            var totalDistance = _distanceCounter.TotalDistance(trail);
            var descentDistance = _distanceCounter.DescentDistance(trail);
            var flatDistance = _distanceCounter.FlatDistance(trail);

        }
    }
}
