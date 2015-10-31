using System;
using Xamarin.Forms;

namespace jbb
{
	public class BeerCarousel : ContentPage
	{
		public BeerCarousel (Beer beer)
		{
			var layout = new RelativeLayout ();

			var overlay = new Image () {
				Aspect = Aspect.AspectFill,
				Source = new FileImageSource () { File = "Overlay.png" }
			};

			var picture = new Image () {
				Aspect = Aspect.AspectFill,
				//Source = new FileImageSource () { File = jbteam.Name }
				Source = beer.ProName
			};

			var name = new Label () {
				Text = beer.Name, 
				FontSize = 30, 
				TextColor = Color.FromHex ("#FF6600"),
				FontFamily = Device.OnPlatform ("HelveticaNeue-Medium", "", "")
			};

			var tagline = new Label () { Text = beer.Taste };

			var scovilleLabel = new Label () {
				Text = "Title:", 
				FontSize = 15, 
				TextColor = Color.FromHex ("#B7A19B"),
				FontFamily = Device.OnPlatform ("HelveticaNeue-CondensedBlack", "sans-serif-condensed", "")
			};

			var scoville = new Label () {
				Text = beer.Type, 
				FontSize = 20, 
				FontFamily = Device.OnPlatform ("HelveticaNeue", "sans-serif", "")
			};

			var details = new StackLayout () {
				Spacing = 10,
				Padding = new Thickness (50, 10),
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {
					name,
					tagline,
					scovilleLabel,
					scoville,
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

