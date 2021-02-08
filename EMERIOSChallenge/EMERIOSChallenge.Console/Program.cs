using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EMERIOSChallenge.Program
{
    public static class Program
    {
        public static IConfiguration config { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        public static int Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                return 1;
            }

            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ICustomConfiguration, CustomConfiguration>(x =>
                    {
                        CustomConfiguration configuracion = new CustomConfiguration();
                        config.GetSection("Configuracion").Bind(configuracion);
                        return configuracion;
                    });

                    services.AddSingleton<IStringsHelper, StringsHelper>();
                    services.AddSingleton<IServiceMatrix, ServiceMatrix>();
                    services.AddSingleton<IServiceIO, ServiceIO>();
                    services.AddSingleton<IMainProgram, MainProgram>();
                    services.AddHostedService<Worker>();
                });
    }
}
