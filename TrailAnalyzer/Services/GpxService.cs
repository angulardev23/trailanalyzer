using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TrailAnalyzer.Services;
using TrailAnalyzer.Models;
using System.IO;
using TrailAnalyzer.Config;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace TrailAnalyzer.Services
{
    public class GpxService : IGpxService
    {
        IOptions<GpxConfig> _gpxConfig;
        public GpxService(IOptions<GpxConfig> gpxConfig)
        {
            _gpxConfig = gpxConfig;
        }

        public string GetTrailBody()
        {
            return File.ReadAllText(_gpxConfig.Value.TrailFilePath);
        }

        public Trail CreateTrail(string gpxContent)
        {
            var xDocument = XDocument.Parse(gpxContent);
            var _nameSpace = xDocument.Root.GetDefaultNamespace();

            var trail = new Trail()
            {
                Name = xDocument.Element(_nameSpace + "gpx")
                    .Element(_nameSpace + "trk")
                    .Element(_nameSpace + "name")
                    .Value,
                Points = new List<Point>()
            };


            foreach (var node in xDocument.Descendants(_nameSpace + "trkseg").Elements(_nameSpace + "trkpt"))
            {
                trail.Points.Add(new Point
                {
                    Longitude = double.Parse(node.Attribute("lon").Value, CultureInfo.InvariantCulture),
                    Latitude = double.Parse(node.Attribute("lat").Value, CultureInfo.InvariantCulture),
                    Elevation = double.Parse(node.Element(_nameSpace + "ele").Value, CultureInfo.InvariantCulture),
                    Time = DateTime.Parse(node.Element(_nameSpace + "time").Value, CultureInfo.InvariantCulture)
                });

            }

            return trail;
        }
    }
}
