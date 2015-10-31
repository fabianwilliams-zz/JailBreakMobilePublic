using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
using SimpleAuth;
#if __IOS__
using UIKit;
using Xam.Plugin.MapExtend.iOSUnified;
#elif __ANDROID__
using Mono;
#endif
using Xamarin.Media;
using Xamarin.Social.Services;
using Xamarin.Social;

namespace jbb
{
	public class BeerDetail : ContentPage 
	{
		OAuthApi api;
		public BeerDetail(Beer b)
		{
			api = new untappedApi("untappd",new untappdAuthenticator(
				"https://untappd.com/oauth/authenticate",
				"https://untappd.com/oauth/authorize",
				"https://adotob.auth0.com/login/callback",
				"C863AC5D23A4208ADFF983D3A2A389715D1C5DAE",
				"8AD653F4794081016B42659B799662C1361A0FC5"));

			var userTokenLabel = new Label ();

			//Padding = new Thickness (0, Device.OnPlatform (10, 10, 10), 0, 0);
			this.Title = b.Name;

			var giftImage = new Image
			{
				Aspect = Aspect.AspectFit,
				BackgroundColor = Color.Gray
			};

			var picUrl = b.Smu;
			if (b.Smu != null)
			{
				giftImage.Source = ImageSource.FromUri(new Uri(picUrl));

			}
			else
			{
				//giftImage.Source = ImageSource.FromUri(new Uri("https://jailbreakbrewing.com/wp-content/uploads/2015/05/SRM-16"));
				giftImage.Source = "infinite_xhalf.png";
			}
			var GiftNameLabel = new Label
			{
				FontAttributes = FontAttributes.Bold,
				Text = b.Name,
				FontSize = 15
			};

			var GiftDesc = new Label
			{
				Text = b.Taste,
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};

			var tweetButton = new Button
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				Text = "Tweet " + b.Name
			};

			var unTappdButton = new Button
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				Text = "Untappd " + b.Name
			};

			unTappdButton.Clicked += async (sender, e) => {
				//await DisplayAlert("UnTapped Name and ID", b.Name + "/ " +b.Utbid, "Ok");
				//var usvc = new UnTappdService();

				//Navigation.PushAsync(new UntappdCheckIn(b));
				Navigation.PushAsync(new UntappdCheckinV2(b));
				//Navigation.PushAsync(new UntappdCheckinV3());
//				try {
//					var account = (await api.Authenticate(new string[]{"openid"})) as OAuthAccount ;
//					var currUserToken = account.Token.ToString();
//					userTokenLabel.Text = currUserToken;
//
//					var client = new System.Net.WebClient(); 
//					client.Headers[System.Net.HttpRequestHeader.ContentType] = 
//						"application/x-www-form-urlencoded"; 
//
//					var checkinstring = "https://api.untappd.com/v4/checkin/add?access_token="+currUserToken;
//					var checkindata = "gmt_offset=-5&timezone=EST&bid="
//						+ b.Utbid +"&rating=4.5&shout=TESTING%20Jailbreak%20MobileApp";
//
//					var response = client.UploadString(checkinstring,checkindata); 
//
//				} catch (Exception ex) {
//					//await DisplayAlert("UnTapped Name and ID", b.Name + "/ " +b.Utbid, "Ok");
//					await DisplayAlert("Something went wrong", b.Name + "/ " +b.Utbid, "Ok");
//				}

			};



			Content = new ScrollView
			{
				Content = new StackLayout
				{
					Spacing = 10,
					Children = { giftImage, GiftNameLabel, GiftDesc, userTokenLabel, unTappdButton }
				}
			};
		}
	}
}

