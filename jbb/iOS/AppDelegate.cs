using System;
using System.Collections.Generic;
using System.Linq;
using ImageCircle.Forms.Plugin.iOS;
using Xam.Plugin.MapExtend.iOSUnified;
using Xam.Plugin.MapExtend.Abstractions;
using Xamarin.Forms;
using System.Threading.Tasks;
#if ! __UNIFIED__
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#else
using Foundation;
using UIKit;
#endif
using MonoTouch.Dialog;
using Xamarin.Media;
using Xamarin.Social.Services;
using Xamarin.Social;

namespace jbb.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

			global::Xamarin.Forms.Forms.Init ();
			MapExtendRenderer.Init();
			Xamarin.FormsMaps.Init ();  //so we can get the map to load
			ImageCircleRenderer.Init (); //so we can get the image circle properties 
			SQLitePCL.CurrentPlatform.Init(); 

			//doing this call here so as to speed up the load when someone goes to the 
			//List of Beer Page

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			window.RootViewController = App.GetMainPage().CreateViewController();
			window.MakeKeyAndVisible();


			App.UIContext = window.RootViewController;
			return true;


//			LoadApplication (new App ());
//
//			return base.FinishedLaunching (app, options);
		}
	}
}

