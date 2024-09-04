global using HYasinDemoApp.Services.Circuits;
global using HYasinDemoApp.Services.DriverStandings;
using Microsoft.Extensions.Logging;

namespace HYasinDemoApp
{
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
                });

            builder.Services.AddSingleton<ICircuitsService, CircuitsService>();
            builder.Services.AddSingleton<IDriverStandingsService, DriverStandingsService>();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            

            return builder.Build();
        }
    }
}
