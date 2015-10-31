using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
#if ! __UNIFIED__
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
#else
using Foundation;
using UIKit;
using MonoTouch.Dialog;
#endif
//using MonoTouch.Dialog;
using Xamarin.Media;
using Xamarin.Social.Services;
using Xamarin.Social;


namespace jbb
{
	public class JBSocialPage : ContentPage
	{
#if __IOS__
		UIWindow window;
		DialogViewController dialog;
#endif

		#region Fields

		private static FacebookService mFacebook;
		private static FlickrService mFlickr;
		private static TwitterService mTwitter;
#if __IOS__
		private static Twitter5Service mTwitter5;
#endif
		#endregion

		public static FacebookService Facebook
		{
			get
			{
				if (mFacebook == null)
				{
					mFacebook = new FacebookService() {
						ClientId = "App ID/API Key from https://developers.facebook.com/apps",
						RedirectUrl = new Uri ("Redirect URL from https://developers.facebook.com/apps")
					};
				}

				return mFacebook;
			}
		}

		public static FlickrService Flickr
		{
			get
			{
				if (mFlickr == null)
				{
					mFlickr = new FlickrService() {
						ConsumerKey = "Key from http://www.flickr.com/services/apps/by/me",
						ConsumerSecret = "Secret from http://www.flickr.com/services/apps/by/me",
					};
				}

				return mFlickr;
			}
		}

		public static TwitterService Twitter
		{
			get
			{
				if (mTwitter == null)
				{
					mTwitter = new TwitterService {
						ConsumerKey = "4RfWVsmq18UyoxtaYYYxHG0jY",
						ConsumerSecret = "eQjVpbPGH8HcJ31LL2JqM7uJyZrovmAGKyePmzOQGVIpLKOa2b",
						CallbackUrl = new Uri ("https://t4s.azure-mobile.net/signin-twitter")
					};
				}

				return mTwitter;
			}
		}
#if __IOS__
		public static Twitter5Service Twitter5
		{
			get
			{
				if (mTwitter5 == null)
				{
					mTwitter5 = new Twitter5Service();
				}

				return mTwitter5;
			}
		}

		private void Share (Service service, StringElement button, Beer myB)
		{
			Item item = new Item {
				Text = "Currently enjoying a glass of " + myB.Name + " beer from @JailbreakBrewCo . You should try it out. Come join me!",
				Links = new List<Uri> {
					new Uri ("http://jailbreakbrewing.com"),
				},
			};

			UIViewController vc = service.GetShareUI (item, shareResult => {
				dialog.DismissViewController (true, null);

				button.GetActiveCell().TextLabel.Text = service.Title + " shared: " + shareResult;
			});
			dialog.PresentViewController (vc, true, null);
			//go back to master tabbed page
			//Navigation.PushAsync (new MasterPage ());
		}
#endif
		public JBSocialPage (Beer currBeer)
		{
		var root = new RootElement ("Get Social about JailBreak");

		var section = new Section ("Breakout and Share");

		var facebookButton = new StringElement ("Share with Facebook");
		facebookButton.Tapped += delegate 
		{
			try
			{
					Share (Facebook, facebookButton, currBeer); 
			}
			catch (Exception ex)
			{
				ShowMessage("Facebook: " + ex.Message);
			}
		};
		section.Add (facebookButton);

		var twitterButton = new StringElement ("Share with Twitter");
		twitterButton.Tapped += delegate 
		{ 
			try
			{
					Share (Twitter, twitterButton, currBeer); 
			}
			catch (Exception ex)
			{
				ShowMessage("Twitter: " + ex.Message);
			}

		};
		section.Add (twitterButton);

		var twitter5Button = new StringElement ("Share with built-in Twitter");
		twitter5Button.Tapped += delegate 
		{
			try
			{
				Share (Twitter5, twitter5Button, currBeer); 
			}
			catch (Exception ex)
			{
				ShowMessage("Twitter5: " +ex.Message);
			}
		};
		section.Add (twitter5Button);

		var flickr = new StringElement ("Share with Flickr");
		flickr.Tapped += () => {
			var picker = new MediaPicker(); // Set breakpoint here
			picker.PickPhotoAsync().ContinueWith (t =>
				{
					if (t.IsCanceled)
						return;

						var item = new Item ("Currently enjoying a @jailbreakbrewery" + currBeer.Name + "Come join me!") {
						Images = new[] { new ImageData (t.Result.Path) }
					};

					Console.WriteLine ("Picked image {0}", t.Result.Path);

					UIViewController viewController = Flickr.GetShareUI (item, shareResult =>
						{
							dialog.DismissViewController (true, null);
							flickr.GetActiveCell().TextLabel.Text = "Flickr shared: " + shareResult;
						});

					dialog.PresentViewController (viewController, true, null);
				}, TaskScheduler.FromCurrentSynchronizationContext());
		};
		section.Add (flickr);

			var backButton = new StringElement ("Back to Beers");
			backButton.Tapped += () => {
				//Navigation.PushAsync(new MasterPage());
				window.Hidden = true;
			};
			section.Add (backButton);

		root.Add (section);
		dialog = new DialogViewController (root);

		window = new UIWindow (UIScreen.MainScreen.Bounds);
		window.RootViewController = new UINavigationController (dialog);
		window.MakeKeyAndVisible ();

	}
		private void ShowMessage(string Message)
		{
			var msgView = new UIAlertView("Error", Message,null,"OK", null);
			msgView.Show();
		}

	}

}

