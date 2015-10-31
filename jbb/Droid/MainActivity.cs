using System;
using ImageCircle.Forms.Plugin.Droid;
//using Xam.Plugin.MapExtend.Droid;
//using Xam.Plugin.MapExtend.Abstractions;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Xamarin.Social.Services;
//using Xamarin.Social;

namespace jbb.Droid
{
	[Activity (Label = "Jailbreak", Icon = "@drawable/jbbicon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			//MapExtendRenderer.Init();
			Xamarin.FormsMaps.Init (this, bundle);  //so we can get the map to load
			ImageCircleRenderer.Init (); //so we can get the image circle properties 

			LoadApplication (new App ());
		}
	}
}

