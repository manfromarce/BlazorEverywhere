using System;
using System.Drawing;
using System.IO;
using System.Text;
using BlazorShared.Data;
using BlazorShared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Photino.Blazor;
using PhotinoBlazorApp.InterfacesImpl;

namespace PhotinoBlazorApp;
internal class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        var appBuilder = PhotinoBlazorAppBuilder.CreateDefault(args);

        appBuilder.Services
            .AddBlazorDesktop()
            .AddHttpClient()
            .AddSingleton<WeatherForecastService>()
            .AddSingleton<WeatherForecastServiceApi>()
            .AddSingleton<IHardware, PhotinoHardware>()
            .AddLogging();

        // register root component and selector
        appBuilder.RootComponents.Add<BlazorShared.App>("app");
        var app = appBuilder.Build();

        // customize window
        app.MainWindow
            .SetMinWidth(300)
            .SetMinHeight(300)
            .Center()
            .SetTitle("Photino Blazor Sample");

        AppDomain.CurrentDomain.UnhandledException += (sender, error) =>
        {
            app.MainWindow.ShowMessage("Fatal exception", error.ExceptionObject.ToString());
        };

        app.Run();
    }
}
