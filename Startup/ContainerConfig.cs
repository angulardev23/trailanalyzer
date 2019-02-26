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
            services.Configure<GpxConfig>(p =>
                settings.Config.GetSection("ApplicationSettings").GetSection("Trail").Bind(p));

            var builder = new ContainerBuilder();
            builder.RegisterType<DistanceCounter>().As<IDistanceCounter>();
            builder.RegisterType<GpxService>().As<IGpxService>();
            //builder.RegisterType<JobService>().As<IJobService>();
            //builder.RegisterType<EmailService>().As<IEmailService>();
            //builder.RegisterType<EmailSender>().As<IEmailSender>();


            builder.Populate(services);

            var container = builder.Build();

            //GlobalConfiguration.Configuration.UseMemoryStorage();
            //GlobalConfiguration.Configuration.UseAutofacActivator(container);

            return new AutofacServiceProvider(container);
        }
    }
}
