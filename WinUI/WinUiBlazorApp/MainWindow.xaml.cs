// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using BlazorShared.Data;
using BlazorShared.Interfaces;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Platform;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUiBlazorApp.InterfacesImpl;
using static Microsoft.Maui.Dispatching.Dispatcher;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiBlazorApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public FrameworkElement _blazorWebView;
        public MauiContext _mauiContext;

        public MainWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddSingleton(GetForCurrentThread()!);
            services.AddMauiBlazorWebView();
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<WeatherForecastServiceApi>();
            services.AddSingleton<IHardware, WinUiHardware>();
#if DEBUG
            services.AddBlazorWebViewDeveloperTools();
#endif
            var mauiBlazorWebView = new BlazorWebView() { HostPage = "wwwroot//index.html" };
            mauiBlazorWebView.RootComponents.Add(new RootComponent()
            {
                ComponentType = typeof(BlazorShared.App),
                Selector = "#app"
            });
            _mauiContext = new MauiContext(services.BuildServiceProvider());
            _blazorWebView = mauiBlazorWebView.ToPlatform(_mauiContext);
            _blazorWebView.HorizontalAlignment = HorizontalAlignment.Stretch;
            _blazorWebView.VerticalAlignment = VerticalAlignment.Stretch;
            Grid.SetRow(_blazorWebView, 1);
            rootGrid.Children.Add(_blazorWebView);
        }

        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            myButton.Content = "Clicked";

            ContentDialog contentDialog = new ContentDialog
            {
                Title = AppDomain.CurrentDomain.FriendlyName,
                Content = "This a WinUI ContentDialog.",
                CloseButtonText = "OK", 
                DefaultButton = ContentDialogButton.Close,
                XamlRoot = this.rootGrid.XamlRoot
            };
            var result = await contentDialog.ShowAsync();
        }
    }
}
