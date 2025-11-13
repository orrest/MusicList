using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicList.ViewModels;
using MusicList.Views;

namespace MusicList.Extensions;

internal static class DependencyInjectionExtensions
{
    public static IHostBuilder ConfigureAppServices(this IHostBuilder host)
    {
        var builder = host.ConfigureServices(
            (_, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
            }
        );

        return builder;
    }
}
