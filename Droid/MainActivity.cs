using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace OneSignalPushPOC.Droid
{
	// LaunchMode = LaunchMode.SingleTask or SingleTop
	// Necessary for current implementation of OneSignal SDK for Android
	[Activity(Label = "OneSignalPushPOC.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, 
	          ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, LaunchMode = LaunchMode.SingleTask)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			Forms.Init(this, bundle);

			LoadApplication(new App());
		}
	}
}
