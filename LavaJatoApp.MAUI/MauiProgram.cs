using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using LavaJatoApp.Application.Interfaces.Services;
using LavaJatoApp.MAUI.DependencyInjection;
using LavaJatoApp.MAUI.Navigation;

namespace LavaJatoApp.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("SourceSans3-Regular.ttf", "SourceSansRegular");
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();
        builder.Services.AddPresentation();

        return builder.Build();
    }
}
