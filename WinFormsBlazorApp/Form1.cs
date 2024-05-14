using BlazorShared.Data;
using BlazorShared.Interfaces;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using WinFormsBlazorApp.InterfacesImpl;

namespace WinFormsBlazorApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
#if DEBUG
		services.AddBlazorWebViewDeveloperTools();
#endif
        services.AddSingleton<WeatherForecastService>();
        services.AddSingleton<WeatherForecastServiceApi>();
        services.AddSingleton<IHardware, WinFormsHardware>();
        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.Services = services.BuildServiceProvider();
        blazorWebView1.RootComponents.Add<BlazorShared.App>("#app");
    }

    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("This is a native Windows Forms MessageBox.", Application.ProductName, buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
    }
}