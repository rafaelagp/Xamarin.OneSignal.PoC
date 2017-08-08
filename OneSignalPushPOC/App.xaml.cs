using Com.OneSignal;
using Xamarin.Forms;

namespace OneSignalPushPOC
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new OneSignalPushPOCPage();
			OneSignal.Current.StartInit("f6b2d037-bcf0-4c56-8e38-48ffcedfbc1a")
					 .EndInit();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
