using System;
using Xamarin.Forms;

namespace jbb
{
	public class MeetOurPeople : ContentPage
	{
		public MeetOurPeople (JBTeam jbteam)
		{
			var layout = new RelativeLayout ();

			var overlay = new Image () {
				Aspect = Aspect.AspectFill,
				Source = new FileImageSource () { File = "Overlay.png" }
			};

			var picture = new Image () {
				Aspect = Aspect.AspectFill,
				//Source = new FileImageSource () { File = jbteam.Name }
				Source = jbteam.PicURL
			};

			var name = new Label () {
				Text = jbteam.Name, 
				FontSize = 30, 
				TextColor = Color.FromHex ("#FF6600"),
				FontFamily = Device.OnPlatform ("HelveticaNeue-Medium", "", "")
			};

			var tagline = new Label () { Text = jbteam.Desc };

			var scovilleLabel = new Label () {
				Text = "Title: " + jbteam.Title, 
				FontSize = 15, 
				TextColor = Color.FromHex ("#B7A19B"),
				FontFamily = Device.OnPlatform ("HelveticaNeue-CondensedBlack", "sans-serif-condensed", "")
			};

//			var scoville = new Label () {
//				Text = jbteam.Title, 
//				FontSize = 20, 
//				FontFamily = Device.OnPlatform ("HelveticaNeue", "sans-serif", "")
//			};

			var emailButton = new Button() {
				Text = "Email " + jbteam.Name
			};

			emailButton.Clicked += (sender, e) => {
				DisplayAlert("Test", "Email Button Pressed", "OK");
				//Device.OpenUri(new Uri("mailto:"+jbteam.OEmail));
			};

			var callButton = new Button() {
				Text = "Call " + jbteam.Name
			};

			callButton.Clicked += (sender, e) => {
				DisplayAlert("Test", "Call Button Pressed", "OK");
				//Device.OpenUri(new Uri("tel:"+jbteam.OPhone));
			};

			var details = new StackLayout () {
				Spacing = 3,
				Padding = new Thickness (50, 10),
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {
					name,
					tagline,
					scovilleLabel,
					emailButton,
					callButton
				}
			};

			layout.Children.Add (
				picture,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height * .5;
				})
			);

			layout.Children.Add (
				details,
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height * .5;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				})
			);

			layout.Children.Add (
				overlay,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				})
			);

			Content = layout;
		}
	}
}

