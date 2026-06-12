using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using LavaJatoApp.Application.Interfaces.Services;
using LavaJatoApp.MAUI.Controls;
using LavaJatoApp.MAUI.DependencyInjection;
using LavaJatoApp.MAUI.Navigation;
using Microsoft.Extensions.Configuration;
using Microsoft.Maui.Handlers;
using Syncfusion.Maui.Core.Hosting;

namespace LavaJatoApp.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore();
        ConfigureAppSettings(builder);
        ConfigureFonts(builder);
        ConfigureServices(builder);
        ConfigureHandlers(builder);
        RegisterSyncfusionLicense(builder.Configuration);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void ConfigureAppSettings(MauiAppBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", true);
    }

    private static void RegisterSyncfusionLicense(IConfiguration configuration)
    {
        string? licenseKey = configuration["Syncfusion:LicenseKey"];

        if (!string.IsNullOrWhiteSpace(licenseKey))
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licenseKey);
    }

    private static void ConfigureFonts(MauiAppBuilder builder)
    {
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("SourceSans3-Regular.ttf", "SourceSansRegular");
            fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
        });
    }


    private static void ConfigureServices(MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();
        builder.Services.AddPresentation();
    }

    private static void ConfigureHandlers(MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler<BorderedEntry, EntryHandler>();
        });
    }
}
