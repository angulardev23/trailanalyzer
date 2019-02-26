using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using TrailAnalyzer.Config;
using TrailAnalyzer.Services;

namespace Startup
{
    public static class ContainerConfig
    {
        public static IServiceProvider ConfigureContainers(IServiceCollection services)
        {
            var settings = new Settings();
            services.AddOptions();

            //bind configuration
            services.Configure<GpxConfig>(p =>
                settings.Config.GetSection("ApplicationSettings").GetSection("Trail").Bind(p));

            //register services
            var builder = new ContainerBuilder();
            builder.RegisterType<DistanceCounter>().As<IDistanceCounter>();
            builder.RegisterType<GpxService>().As<IGpxService>();
            builder.RegisterType<ElevetionCounter>().As<IElevationCounter>();
            builder.RegisterType<SpeedCounter>().As<ISpeedCounter>();
            builder.RegisterType<TimeCounter>().As<ITimeCounter>();


            builder.Populate(services);

            var container = builder.Build();

            //GlobalConfiguration.Configuration.UseMemoryStorage();
            //GlobalConfiguration.Configuration.UseAutofacActivator(container);

            return new AutofacServiceProvider(container);
        }
    }
}
