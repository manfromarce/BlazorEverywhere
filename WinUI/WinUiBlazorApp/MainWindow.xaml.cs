// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using BlazorShared.Data;
using BlazorShared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
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
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUiBlazorApp.InterfacesImpl;
using Microsoft.AspNetCore.Components.WebView.WinUI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiBlazorApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();
            serviceCollection.AddScoped(sp => new HttpClient());
            serviceCollection.AddSingleton<WeatherForecastService>();
            serviceCollection.AddSingleton<WeatherForecastServiceApi>();
            serviceCollection.AddSingleton<IHardware, WinUiHardware>();
#if DEBUG
            serviceCollection.AddBlazorWebViewDeveloperTools();
#endif
            blazorWebView.Services = serviceCollection.BuildServiceProvider();  
            blazorWebView.RootComponents.Add(new RootComponent()
            {
                ComponentType = typeof(BlazorShared.App),
                Selector = "#app"
            });
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
