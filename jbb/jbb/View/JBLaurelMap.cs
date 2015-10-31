using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
#if __IOS__
using UIKit;
using Xam.Plugin.MapExtend.iOSUnified;
#elif __ANDROID__
using Mono;
#endif
using System.Threading;

namespace jbb
{
	public class JBLaurelMap : ContentPage
	{
		public JBLaurelMap ()
		{
			Title = "JailBreak Laurel";
			BackgroundColor = Color.White;

			var lense = new Image () {
				Source = new FileImageSource () { File = "maplense.png" },
				Aspect = Aspect.AspectFill,
				IsOpaque = true,
				InputTransparent = true
			};

			var map = new Map (
				MapSpan.FromCenterAndRadius (
					new Position(39.124164, -76.823165),Distance.FromMiles(0.3))){
				IsShowingUser = true,
			};

			var jbLaurelpin = new Pin {
				Type = PinType.Place,
				Position = new Position (39.124164, -76.823165),
				Label = "JailBreak Laurel Brewery",
				Address = "9445 Washington Blvd N, STE F, Laurel, MD 20723"
			};


			map.Pins.Add (jbLaurelpin);


			jbLaurelpin.Clicked += (sender, e) => {
				//DisplayAlert("Go Directly to Jail-break", "Will Launch your Mapp App", "Ok");
				Device.OpenUri(new Uri("http://maps.apple.com/?daddr=39.124164,-76.823165"));
			};

			var stack = new StackLayout () {
				Padding = new Thickness (10),
				Children = {

					new Label () {
						FontAttributes = FontAttributes.Bold,
						Text = "Best Mode of Travel:",
						TextColor = Color.FromHex ("852F29"),
					},
					new Label () {
						Text = "Click the Navigation Pin to Open your Map App for Navigation or...Coming from I-95, take Rt. 32 to US 1, head South pass Carmax, we are on the Left",
						FontSize = 14,

					},
					new Label () {
						FontAttributes = FontAttributes.Bold,
						Text = "Beer Tours Available:",
						TextColor = Color.FromHex ("852F29"),
					},
					new Label () {
						Text = "Wed. - Sat. 3:00 PM to 9:00 PM",
						FontSize = 14
					},
				}	
			};

			var orderonline = new StackLayout () {
				BackgroundColor = Color.FromHex ("E6A93D"),
				Children = {

					new Label () { 
						Text = "Come and Plan your Escape!",
						FontSize = 22,
						FontAttributes = FontAttributes.Bold,
						TextColor = Color.White,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					},
				}	
			};



			RelativeLayout relativeLayout = new RelativeLayout () {
				HeightRequest = 100,
			};

			relativeLayout.Children.Add (
				map,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				})
			);

			relativeLayout.Children.Add (
				lense,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				})
			);

			relativeLayout.Children.Add (
				stack,
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 10;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height - (parent.Width + 50);
				})
			);

			relativeLayout.Children.Add (
				orderonline,
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height - 50;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 50;
				})
			);

			this.Content = relativeLayout;

		}
	}
}

