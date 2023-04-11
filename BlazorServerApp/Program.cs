using BlazorServerApp.InterfacesImpl;
using BlazorShared.Data;
using BlazorShared.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorServerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            //builder.Services.AddHttpClient("Test", configureClient => configureClient.BaseAddress = new Uri(@"https://localhost:7257"));
            //builder.Services.AddScoped(sp => new HttpClient());
            builder.Services.AddHttpClient();

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<WeatherForecastServiceApi>();
            builder.Services.AddScoped<IHardware, BlazorServerHardware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}