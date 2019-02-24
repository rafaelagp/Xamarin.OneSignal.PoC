using System;
using Xamarin.Forms;

namespace SilentPushPoC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            App.OnPushNotificationReceived += HandlePushNotificationReceived;
            InitializeComponent();
        }

        void HandlePushNotificationReceived(object sender, EventArgs e) =>
            Device.BeginInvokeOnMainThread(() => 
                StatusLabel.Text += $"{DateTime.Now.ToString("s")} Received silent push notification!");
    }
}
