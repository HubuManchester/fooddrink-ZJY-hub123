using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace FoodDrinkMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureMauiHandlers(handlers =>
            {
                SwitchHandler.Mapper.AppendToMapping("HideOnOffText", (handler, view) =>
                {
#if WINDOWS
                    handler.PlatformView.OnContent = "On";
                    handler.PlatformView.OffContent = "Off";
#endif
                });
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
