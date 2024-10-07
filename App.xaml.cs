using System.Windows;
using VolvoApp.Encryption;
using Microsoft.Extensions.DependencyInjection;
using VolvoApp.Data;

namespace VolvoApp {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private IServiceProvider _serviceProvider;

        public App() {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public void ConfigureServices(ServiceCollection services) {
            services.AddSingleton<IDatabaseService, InMemoryDatabaseService>(); // change to AddScoped when using SQL
            services.AddSingleton<IEncryptor, TwofishEncryptor>();

            services.AddSingleton<MainWindow>();
            services.AddTransient<ChooseWindow>();
            services.AddTransient<EncryptWindow>();
            services.AddTransient<DecryptWindow>();
        }

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
