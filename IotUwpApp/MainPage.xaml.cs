using IotUwpApp.Models;
using IotUwpApp.Services;
using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IotUwpApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static readonly DeviceClient deviceClient = DeviceClient.CreateFromConnectionString("HostName=micke-1219.azure-devices.net;DeviceId=IotUwpApp;SharedAccessKey=vrWp+/fi98PeVgnabxSpv3X+5liwK3R/ZeB8sEPW82w=", TransportType.Mqtt);
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(200, 200));
        }

        private async void sendMessage_Click(object sender, RoutedEventArgs e)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
            await new MessageDialog($"Weather data sent! - ({DeviceService.json.Replace("{", "").Replace("}", "").Replace("\"", "")})").ShowAsync();
        }
    }
}
