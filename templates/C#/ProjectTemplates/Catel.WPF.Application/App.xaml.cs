namespace $safeprojectname$
{
    using System.Windows;

    using $safeprojectname$.Views;

    using Catel.IoC;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
#pragma warning disable IDISP006 // Implement IDisposable
        private readonly IHost _host;
#pragma warning restore IDISP006 // Implement IDisposable

        public App()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddCatelCore();
                    services.AddCatelMvvm();

                    services.AddLogging(x =>
                    {
                        x.AddDebug();
                    });

                    // TODO: Register custom types in the service collection
                    //services.AddTransient<IMyInterface, MyClass>();
                });

            _host = hostBuilder.Build();

            IoCContainer.ServiceProvider = _host.Services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceProvider = _host.Services;

            serviceProvider.CreateTypesThatMustBeConstructedAtStartup();

            var mainWindow = ActivatorUtilities.CreateInstance<MainWindow>(serviceProvider);
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}