using AnimeVoices.DataAccess.Api;
using AnimeVoices.DataAccess.Repositories;
using AnimeVoices.DB;
using AnimeVoices.Stores;
using AnimeVoices.Utilities;
using AnimeVoices.ViewModels;
using AnimeVoices.ViewModels.Content;
using AnimeVoices.ViewModels.Content.InfoPanels;
using AnimeVoices.ViewModels.Content.MoreData;
using AnimeVoices.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace AnimeVoices
{
    public partial class App : Application
    {
        public IServiceProvider? ServiceProvider { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            // Set up DI container
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();


            var appDb = ServiceProvider.GetRequiredService<AppDbContext>();
            var userDb = ServiceProvider.GetRequiredService<UserDbContext>();

            // Because app is just for local use - ensure local db creation
            appDb.Database.EnsureCreated();
            userDb.Database.EnsureCreated();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
                // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
                DisableAvaloniaDataAnnotationValidation();
                var mw = ServiceProvider.GetRequiredService<MainWindow>();
                var vm = ServiceProvider.GetRequiredService<MainWindowViewModel>();

                desktop.MainWindow = mw;
                desktop.MainWindow.DataContext = vm;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            Uri baseAdress = new("https://api.jikan.moe/v4/");

            // Register Messenger
            services.AddSingleton<IMessenger, WeakReferenceMessenger>();

            // Register Stores
            services.AddSingleton<AnimeStore>();
            services.AddSingleton<CharacterStore>();
            services.AddSingleton<SeiyuuStore>();

            // Register APIs
            services.AddHttpClient<ISeiyuuApi, JikanSeiyuuApi>(client =>
            {
                client.BaseAddress = baseAdress;
            });
            services.AddHttpClient<IAnimeApi, JikanAnimeApi>(client =>
            {
                client.BaseAddress = baseAdress;
            });
            //services.AddScoped<ISeiyuuApi, JikanSeiyuuApi>();
            //services.AddScoped<IAnimeApi, JikanAnimeApi>();

            // Register Database Context
            services.AddDbContext<AppDbContext>(options =>
            {
                string dbPath = Path.Combine(AppContext.BaseDirectory, AppSettings.AppDbFileName);
                options.UseSqlite($"Data Source={dbPath}");
            });
            services.AddDbContext<UserDbContext>(options =>
            {
                string dbPath = Path.Combine(AppContext.BaseDirectory, AppSettings.UsersDbFileName);
                options.UseSqlite($"Data Source={dbPath}");
            });

            // Register Databases
            services.AddSingleton<IAppDatabase, AppDatabase>();
            services.AddSingleton<IUserDatabase, UserDatabase>();

            // Register Repositories
            services.AddSingleton<IAnimeRepository, AnimeRepository>();
            services.AddSingleton<ICharacterRepository, CharacterRepository>();
            services.AddSingleton<ISeiyuuRepository, SeiyuuRepository>();

            // Register MainWindow
            services.AddSingleton<MainWindow>();

            // Register ViewModels
            //Main Window ViewModels
            services.AddSingleton<TopBarViewModel>();
            services.AddSingleton<MainMenuViewModel>();
            services.AddSingleton<UserPanelViewModel>();
                //Content
                services.AddSingleton<OverviewViewModel>();
                services.AddSingleton<AnimeInfoViewModel>();
                services.AddSingleton<AboutAppViewModel>();
                services.AddSingleton<SettingsViewModel>();
                services.AddSingleton<GetMoreDataViewModel>();
                    //Info Panels
                    services.AddSingleton<AnimeInfoPanelViewModel>();
                    services.AddSingleton<CharacterInfoPanelViewModel>();
                    services.AddSingleton<ResultInfoPanelViewModel>();
                    //MoreData
                    services.AddSingleton<GetSingleDataViewModel>();
                    services.AddSingleton<GetTopDataViewModel>();
            //Main Window ViewModel
            services.AddSingleton<MainWindowViewModel>();

        }
    }
}