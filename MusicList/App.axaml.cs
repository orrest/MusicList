using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicList.Extensions;
using MusicList.Views;

namespace MusicList;

public partial class App : Application
{
    public static IHost Host { get; private set; } = null!;

    public App()
    {
        Host = Microsoft
            .Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureAppServices()
            .Build();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit.
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();

            var mainView = Host.Services.GetRequiredService<MainWindow>();
            desktop.MainWindow = mainView;
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var mainView = Host.Services.GetRequiredService<MainWindow>();
            singleViewPlatform.MainView = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove = BindingPlugins
            .DataValidators.OfType<DataAnnotationsValidationPlugin>()
            .ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}
