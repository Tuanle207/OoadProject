

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SE214L22.Contract.Util;
using SE214L22.Core.AppSession;
using SE214L22.DI;
using SE214L22.View;
using System;
using System.Windows;

namespace SE214L22
{

    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            host = Host.CreateDefaultBuilder()  // Use default settings
                .ConfigureAppConfiguration((context, builder) =>
                {
                    // Add other configuration files...
                    builder.AddJsonFile("appsettings.development.json", optional: true);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging(logging =>
                {
                    // Add other loggers...
                })
                .Build();

            DIContainer.Initialize(host.Services);
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.RegisterViewModels();
            services.RegisterViews();
            services.RegisterServices();
            services.RegisterRepositories();
            services.AddSingleton<ISession, Session>();
        }

        private async void OnStart(object sender, StartupEventArgs e)
        {
            await host.StartAsync();

            var wd = new LoginWindow();
            wd.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
