using System;
using System.Collections.Generic;
using Com.OneSignal;
using Com.OneSignal.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SilentPushPoC
{
    public partial class App : Application
    {
        public static event EventHandler OnPushNotificationReceived;

        public App()
        {
            SetUpOnePushNotifications();
            InitializeComponent();

            MainPage = new MainPage();
        }

        void HandleNotificationReceived(OSNotification notification) => 
            OnPushNotificationReceived?.Invoke(this, EventArgs.Empty);

        void SetUpOnePushNotifications()
        {
            OneSignal.Current
                     .StartInit("")
                     .HandleNotificationReceived(HandleNotificationReceived)
                     .EndInit();

            OneSignal.Current.SendTags(new Dictionary<string, string>
            {
                { "cpf", ""}, { "device_id", "" }
            });
        }
    }
}
