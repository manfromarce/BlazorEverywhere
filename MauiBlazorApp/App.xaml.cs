namespace MauiBlazorApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        
        // uses Blazor menu included in BlazorShared like Blazor-Server/WASM
        //MainPage = new MainPage();

        // uses Maui menu e.g. TabbedPage
        MainPage = new MainPageTabbed();
    }
}
