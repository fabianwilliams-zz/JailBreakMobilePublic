using System;
using Xamarin.Forms;

namespace jbb
{
	public class MeetOurFolks : ContentPage
	{
		public MeetOurFolks (JBTeam jbteam)
		{
			Padding = new Thickness (10, Device.OnPlatform (0, 0, 0), 10, 0);

			var picture = new Image () {
				Aspect = Aspect.AspectFill,
				HeightRequest = 250,
				WidthRequest = 250,
				//Source = new FileImageSource () { File = jbteam.Name }
				Source = jbteam.PicURL
			};

			var name = new Label () {
				Text = jbteam.Name, 
				FontSize = 20, 
				TextColor = Color.FromHex ("#FF6600"),
				FontFamily = Device.OnPlatform ("HelveticaNeue-Medium", "", "")
			};

			var tagline = new Label () { 
				Text = jbteam.Desc,
				FontSize = 13
			};

			var scovilleLabel = new Label () {
				Text = "Title: " + jbteam.Title, 
				FontSize = 13, 
				TextColor = Color.FromHex ("#B7A19B"),
				FontFamily = Device.OnPlatform ("HelveticaNeue-CondensedBlack", "sans-serif-condensed", "")
			};

			var emailButton = new Button() {
				Text = "Email " + jbteam.Name
			};

			emailButton.Clicked += (sender, e) => {
				//DisplayAlert("Test", "Email Button Pressed", "OK");
				//Device.OpenUri(new Uri("mailto:"+jbteam.OEmail));
			};

			var callButton = new Button() {
				Text = "Call " + jbteam.Name
			};

			callButton.Clicked += (sender, e) => {
				//DisplayAlert("Test", "Call Button Pressed", "OK");
				//Device.OpenUri(new Uri("tel:"+jbteam.OPhone));
			};


			//region
			StackLayout stack = new StackLayout {
				Spacing = 3,
				Orientation = StackOrientation.Vertical,
				Children = {
					new StackLayout {
						Children = {picture}
					},
					name,
					tagline,
					scovilleLabel,
				}
			};

			ScrollView scroll = new ScrollView {
				Content = stack
			};
			Content = scroll;
			//end region

		}
	}
}

