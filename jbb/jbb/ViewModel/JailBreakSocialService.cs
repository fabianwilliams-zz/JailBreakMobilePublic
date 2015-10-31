using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
#if ! __UNIFIED__
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
#elif __ANDROID__
using Mono;
#elif __IOS__
using UIKit;
using MonoTouch.Dialog;
#else
using Foundation;
using UIKit;
#endif
//using MonoTouch.Dialog;
using Xamarin.Media;
using Xamarin.Social.Services;
using Xamarin.Social;


namespace jbb
{
	public class JailBreakSocialService
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
		public void Share (Service service, UITextView t)
		{
			Item item = new Item {
				Text = "I'm sharing great things using Xamarin!",
				Links = new List<Uri> {
					new Uri ("http://xamarin.com"),
				},
			};

			UIViewController vc = service.GetShareUI (item, shareResult => {
				dialog.DismissViewController (true, null);

				t.Text = service.Title + " shared: " + shareResult;
			});
			dialog.PresentViewController (vc, true, null);
		}
#endif

//		public void Share (Service service, StringElement button)
//		{
//			Item item = new Item {
//				Text = "I'm sharing great things using Xamarin!",
//				Links = new List<Uri> {
//					new Uri ("http://xamarin.com"),
//				},
//			};
//
//			UIViewController vc = service.GetShareUI (item, shareResult => {
//				dialog.DismissViewController (true, null);
//
//				button.GetActiveCell().TextLabel.Text = service.Title + " shared: " + shareResult;
//			});
//			dialog.PresentViewController (vc, true, null);
//		}



	}
}

