using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorShared.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BlazorShared.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<BlazorShared.Data.WeatherForecastService>();
builder.Services.AddSingleton<BlazorShared.Data.WeatherForecastServiceApi>();
builder.Services.AddSingleton<IHardware, BlazorShared.InterfacesImpl.Hardware>();

await builder.Build().RunAsync();
