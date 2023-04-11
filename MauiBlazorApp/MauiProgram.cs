using Microsoft.Extensions.Logging;
using MauiBlazorApp.InterfacesImpl;
using BlazorShared.Data;
using BlazorShared.Interfaces;

namespace MauiBlazorApp;

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

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<WeatherForecastServiceApi>();
		builder.Services.AddSingleton<IHardware, MauiHardware>();

		return builder.Build();
	}
}
