using AnimeVoices.MVVM.ViewModels;
using AnimeVoices.MVVM.Views;
using AnimeVoices.Services;
using System;
using System.IO;
using System.Net.Http;
using System.Windows;

namespace AnimeVoices
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            bool test = true;

            // Register services first
            ServiceLocator.Register<INavigationService>(() => new NavigationService());

            // Register repositories with unique names
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(baseDirectory, "animesTestFile.json");
            ServiceLocator.Register<IAnimeRepository>(() => new JsonAnimeRepository(jsonFilePath), "JsonRepository");
            ServiceLocator.Register<IAnimeRepository>(() => new ApiAnimeRepository(new HttpClient()), "ApiRepository");

            // Register ViewModels with appropriate repository
            ServiceLocator.Register(() => new MainViewModel(ServiceLocator.Resolve<INavigationService>()));
            ServiceLocator.Register(() => new HomeViewModel(ServiceLocator.Resolve<INavigationService>()));
            ServiceLocator.Register(() => new VoicesViewModel(ServiceLocator.Resolve<INavigationService>(), ServiceLocator.Resolve<IAnimeRepository>("JsonRepository")));
            //ServiceLocator.Register(() => new SettingsViewModel(ServiceLocator.Resolve<INavigationService>(), ServiceLocator.Resolve<IAnimeRepository>("ApiRepository")));

            // Resolve MainViewModel to kick off the application
            var mainViewModel = ServiceLocator.Resolve<MainViewModel>();

            var mainWindow = new MainView
            {
                DataContext = mainViewModel
            };

            mainWindow.Show();
        }
    }
}
