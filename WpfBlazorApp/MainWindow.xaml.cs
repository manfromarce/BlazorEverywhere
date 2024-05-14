using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlazorShared.Data;
using BlazorShared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WpfBlazorApp.InterfacesImpl;

namespace WpfBlazorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var services = new ServiceCollection();
            services.AddWpfBlazorWebView();
#if DEBUG
		    services.AddBlazorWebViewDeveloperTools();
#endif            
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<WeatherForecastServiceApi>();
            services.AddSingleton<IHardware, WpfHardware>();
            Resources.Add("services", services.BuildServiceProvider());

            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a native WPF MessageBox.", AppDomain.CurrentDomain.FriendlyName, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
