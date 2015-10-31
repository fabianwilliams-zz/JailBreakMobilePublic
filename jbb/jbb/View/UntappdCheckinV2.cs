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



namespace jbb
{
	public class UntappdCheckinV2 : ContentPage
	{
		Slider ratingsSlider = new Slider {
			Minimum = 0d,
			Maximum = 5d,
			Value = 3.5d,
			VerticalOptions = LayoutOptions.CenterAndExpand
		};


		Label mySliderScore = new Label {
			Text = "",
			Font= Font.SystemFontOfSize(NamedSize.Default),
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.CenterAndExpand
		};

		Label mySliderlabel = new Label {
			Text = "Move Slider to Rate Beer",
			Font= Font.SystemFontOfSize(NamedSize.Micro),
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.CenterAndExpand
		};

		Label myStarslabel = new Label {
			Text = "stars"
		};

		double sliderVal;

		OAuthApi api;

		public UntappdCheckinV2 (Beer currb)
		{
			Title = "Untappd CheckIn: " + currb.Name;

			api = new untappedApi("untappd",new untappdAuthenticator(
				"https://untappd.com/oauth/authenticate",
				"https://untappd.com/oauth/authorize",
				"https://adotob.auth0.com/login/callback",
				"C863AC5D23A4208ADFF983D3A2A389715D1C5DAE",
				"8AD653F4794081016B42659B799662C1361A0FC5"));

			var userTokenLabel = new Label ();
			var checkInReply = new Label ();

			var beerImage = new Image
			{
				Aspect = Aspect.Fill,
				Source = ImageSource.FromUri(new Uri(currb.ProName))
			};

			var shoutEntryLabel = new Label {
				Text = "Tell us about " + currb.Name + ":",
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			var shoutEntry = new Entry {
				Placeholder = "How was the beer? Leave a note...",
				HorizontalOptions = LayoutOptions.Start,
				//VerticalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100
			};

			var checkInButton = new Button {
				Text = "Check In"
			};
					
			checkInButton.Clicked += async (sender, e) => {
				//await DisplayAlert("UnTapped Name and ID", b.Name + "/ " +b.Utbid, "Ok");
				//var usvc = new UnTappdService();
				try {
					var account = (await api.Authenticate(new string[]{"openid"})) as OAuthAccount ;
					var currUserToken = account.Token.ToString();
					userTokenLabel.Text = currUserToken;

					var client = new System.Net.WebClient(); 
					client.Headers[System.Net.HttpRequestHeader.ContentType] = 
						"application/x-www-form-urlencoded"; 

					var checkinstring = "https://api.untappd.com/v4/checkin/add?access_token="+currUserToken;
					var checkindata = "gmt_offset=-5&timezone=EST&bid="
						+ currb.Utbid +"&rating="+sliderVal+ "&shout=" + System.Net.WebUtility.UrlEncode(shoutEntry.Text);

					var response = client.UploadString(checkinstring,checkindata); 

					if (response != null)
					{
						checkInReply.Text = "Congratulations, You've Just Checked In. Click the Back Button and Experience more Beer!";
						checkInButton.IsVisible = false;
					}

				} catch (Exception ex) {
					//await DisplayAlert("UnTapped Name and ID", b.Name + "/ " +b.Utbid, "Ok");
					await DisplayAlert("Something went wrong", ex.Message, "Ok");
				}

			};

			ratingsSlider.ValueChanged += HandleSliderChangedEvent;

			Padding = new Thickness (20, Device.OnPlatform (20, 0, 0), 20, 10);

			Content = new StackLayout {
				Spacing = 1,
				Orientation = StackOrientation.Vertical,
				Children = 
				{
					beerImage,
					shoutEntryLabel,
					shoutEntry,
					mySliderlabel,
					ratingsSlider,
					new StackLayout {
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Children = 
						{
							mySliderScore,
							myStarslabel
						}
					},
					new StackLayout {
						Orientation = StackOrientation.Vertical,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						Children = {
							checkInReply,
							checkInButton
						}
					}
				}

			};


		}

		private void HandleSliderChangedEvent (object sender, EventArgs e)
		{

			sliderVal = Math.Round(ratingsSlider.Value, 1);
			sliderVal = sliderVal * 2;
			sliderVal = Math.Round (sliderVal,MidpointRounding.AwayFromZero);
			sliderVal = sliderVal / 2;
			mySliderScore.Text = sliderVal.ToString();
		}
	}
}

