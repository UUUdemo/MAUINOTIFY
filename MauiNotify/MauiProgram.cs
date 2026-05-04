using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;

namespace MauiNotify;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseLocalNotification()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register notification service
        builder.Services.AddSingleton<Services.NotificationService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        var app = builder.Build();

#if WINDOWS
        // Initialize Windows Toast notification on startup (required for MSIX packaged mode)
        LocalNotificationCenter.Current.RequestNotificationPermission();
#endif

        return app;
    }
}
