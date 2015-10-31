using System;
using Xamarin.Forms;

namespace jbb
{
	public class JBHomePage : ContentPage
	{
		public JBHomePage ()
		{
			Title = "Welcome to Jailbreak Brewing Co";

			AbsoluteLayout peakLayout = new AbsoluteLayout {
				HeightRequest = 250,
				BackgroundColor = Color.Black
			};

			//Kasey wants to see the Color grey or standout for clickable

			var title = new Label {
				Text = "Direct me to the Taproom",
				FontSize = 20,
				FontFamily = "AvenirNext-DemiBold",
				TextColor = Color.White
			};

//			var where = new Label { 
//				Text = "Laurel, MD 20723",
//				//FontSize = 10,
//				TextColor = Color.FromHex ("#ddd"),
//				FontFamily = "AvenirNextCondensed-Medium" 
//			};

			var image = new Image () {
				Source = ImageSource.FromFile ("JailBreakBWLogo.png"),
				Aspect = Aspect.AspectFill,
			};

			var overlay = new BoxView () {
				Color = Color.Black.MultiplyAlpha (.7f)
				//Color = Color.Yellow //I use this so i can measure my screen since black blends into black
			};

			var pin = new Image () {
				Source = ImageSource.FromFile ("pin.png"),
				HeightRequest = 25,
				WidthRequest = 25
			};

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += OnTapGestureRecognizerTapped;
			pin.GestureRecognizers.Add (tapGestureRecognizer);
			title.GestureRecognizers.Add (tapGestureRecognizer);

			var description = new Frame () {
				Padding = new Thickness (10, 5),
				HasShadow = false,
				BackgroundColor = Color.Transparent,
				Content = new Label () {
					FontSize = 17,
					//TextColor = Color.FromHex ("#ddd"),
					TextColor = Color.Black,
					Text = "Jailbreak is a freedom expression. Beginning in 2013 and becoming fully operational in 2014, our artfully crafted beer is meant to be an escape from whatever drama is present in your life. We are made up of professionals from various industries all brought together by the common desire to make something different and do something with our lives that has more purpose."
				}
			};

			var jbBreweryLarge = new Image () {
				//Source = ImageSource.FromFile("JB_brewery-large.jpg"),
				Source = ImageSource.FromFile("brew6_bw_cropped.jpg"),
				//Source = ImageSource.FromFile("iPhone6Launch.png"),
				Aspect = Aspect.AspectFit
			};

			var learnMoreButton = new Button {
				Text = "Break In!",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.EndAndExpand,
				BorderWidth = 2,
				BorderColor = Color.White,
				BackgroundColor = Color.Black
			};

			learnMoreButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new MasterPage());
			};



			AbsoluteLayout.SetLayoutFlags (overlay, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (overlay, new Rectangle (0, 1, 1, 0.2));

			AbsoluteLayout.SetLayoutFlags (image, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds (image, new Rectangle (0f, 0f, 1f, 1f));

			AbsoluteLayout.SetLayoutFlags (title, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds (title, 
				new Rectangle (0.1, 0.85, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
			);

//			AbsoluteLayout.SetLayoutFlags (where, AbsoluteLayoutFlags.PositionProportional);
//			AbsoluteLayout.SetLayoutBounds (where, 
//				new Rectangle (0.1, 0.95, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
//			);

			AbsoluteLayout.SetLayoutFlags (pin, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds (pin, 
				new Rectangle (0.95, 0.9, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize)
			);

			peakLayout.Children.Add (image);
			peakLayout.Children.Add (overlay);
			peakLayout.Children.Add (title);
//			peakLayout.Children.Add (where);
			peakLayout.Children.Add (pin);

			Content = new StackLayout () {
				//Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0), //not needed anymore since Im putting in a Navigation Page
				//BackgroundColor = Color.FromHex ("#333"),
				BackgroundColor = Color.White,
				Children = {
					peakLayout,
					jbBreweryLarge,
					learnMoreButton,
				}	
			};

		}
		void OnTapGestureRecognizerTapped(object sender, EventArgs args)
		{
			Navigation.PushAsync(new JBLaurelMap());
		}
	}
}

