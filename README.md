# BlazorEverywhere
This project shows how to easily reuse Blazor UI and code across multiple web and hybrid projects.

### Supported platforms
- Blazor WebAssembly hosted (Client + Server) (Web)
- Blazor Server (Web)
- .NET MAUI + [BlazorWebView](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/maui?view=aspnetcore-7.0) (Windows, MacOS, iOS, Android)
- WPF + [BlazorWebView](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/wpf?view=aspnetcore-7.0) (Windows)
- Windows Forms + [BlazorWebView](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/windows-forms?view=aspnetcore-7.0) (Windows)
- WinUI 3 + [MAUI Embedding](https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/native-embedding?view=net-maui-7.0) (Windows). Thanks to everyone who described the required workarounds in [this issue](https://github.com/dotnet/maui/issues/7380) the project builds and runs properly, but there are drawbacks, e.g. WinUi assets can't be used because they break the build, so they have been replaced with MAUI assets. Hopefully BlazorWebView for WinUI will be officially supported in the future so that some of these workarounds will no longer be needed.
- [Photino.Blazor](https://github.com/tryphotino/photino.Blazor) (Windows, MacOS, Linux)

Other frameworks will be added in the future.

### How to use
1. Clone this repo
`git clone github.com/manfromarce/BlazorEverywhere`
2. Put most of your code can be put in the BlazorShared project which is referenced by all other projects
4. Build and run the desired targets. You can remove projects that you don't need.

Some sample code is already present, mainly to show how to mix native controls and Blazor and how to use JavaScript interop.
