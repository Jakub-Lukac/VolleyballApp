using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using VolleyballApp.ViewModels;
using VolleyballApp.Views;

namespace VolleyballApp
{
    public partial class App : Application
    {
        public App()
        {
            ServiceCollection serviceCollection = new();
            serviceCollection.ConfigureServices();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Register ViewModels as singleton
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<GamesViewModel>();
            services.AddSingleton<PlayerRostersViewModel>();
            services.AddSingleton<ExercisesViewModel>();

            // Register Views
            services.AddSingleton<GamesView>();
            services.AddSingleton<PlayerRostersView>();
            services.AddSingleton<ExercisesView>();

            // Register MainWindow and inject MainViewModel into it
            services.AddSingleton<MainWindow>();

        }
    }
}
