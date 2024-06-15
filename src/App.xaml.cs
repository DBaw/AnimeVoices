using AnimeVoices.MVVM.ViewModels;
using AnimeVoices.MVVM.Views;
using AnimeVoices.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

            // Register services first
            ServiceLocator.Register<INavigationService>(() => new NavigationService());

            // Register ViewModels
            ServiceLocator.Register(() => new MainViewModel(ServiceLocator.Resolve<INavigationService>()));
            ServiceLocator.Register(() => new HomeViewModel(ServiceLocator.Resolve<INavigationService>()));
            ServiceLocator.Register(() => new VoicesViewModel(ServiceLocator.Resolve<INavigationService>()));
            //ServiceLocator.Register(() => new SettingsViewModel(ServiceLocator.Resolve<INavigationService>()));

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
