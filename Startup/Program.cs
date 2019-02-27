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

            //init services instances
            var _distanceCounter = serviceProvider.GetService<IDistanceCounter>();
            var _elevationCounter = serviceProvider.GetService<IElevationCounter>();
            var _speedCounter = serviceProvider.GetService<ISpeedCounter>();
            var _timeCounter = serviceProvider.GetService<ITimeCounter>();
            var _gpxService = serviceProvider.GetService<IGpxService>();

            var trail = _gpxService.CreateTrail(_gpxService.GetTrailBody());

            //distance counting
            var climbingDistance = _distanceCounter.ClimbingDistance(trail);
            var totalDistance = _distanceCounter.TotalDistance(trail);
            var descentDistance = _distanceCounter.DescentDistance(trail);
            var flatDistance = _distanceCounter.FlatDistance(trail);

            //speed counting
            var averageClimbingSpeed = _speedCounter.AverageClimbingSpeed(trail);
            var averageDescentSpeed = _speedCounter.AverageDescentSpeed(trail);
            var averageFlatSpeed = _speedCounter.AverageFlatSpeed(trail);
            var averageSpeed = _speedCounter.AverageSpeed(trail);
            var maxiumumSpeed = _speedCounter.MaxiumumSpeed(trail);
            var minimumSpeed = _speedCounter.MinimumSpeed(trail);

            //Elevation counting
            //_elevationCounter.AverageElevation(tra)
        }
    }
}
