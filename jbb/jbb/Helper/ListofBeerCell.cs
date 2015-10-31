using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace jbb
{
	public class ListofBeerCell : ViewCell
	{
		public ListofBeerCell ()
		{
			var image = new Image
			{
				Aspect = Aspect.AspectFill,
				WidthRequest = 150,

				//HorizontalOptions = LayoutOptions.StartAndExpand,
				//VerticalOptions = LayoutOptions.Center
			};
			image.SetBinding(Image.SourceProperty, new Binding("ProName"));

			var rslayout = CreateRightSideLayout ();

			var ctrlayout = CreateMiddleLayout ();

			var leftImageLayout = new StackLayout()
			{
				Spacing = 1,
				Padding = new Thickness (5, 5, 0, 5),
				Orientation = StackOrientation.Horizontal,
				Children = { image, ctrlayout, rslayout}
			};
			View = leftImageLayout;
		}

		static StackLayout CreateMiddleLayout()
		{

			var preBlank = new Label {
				Text = "",
				FontSize = 11
			};
			var preAbv = new Label {
				Text = "Abv",
				FontSize = 11,
				FontAttributes = FontAttributes.Bold
			};

			var preIbu = new Label {
				Text = "Ibu",
				FontSize = 11,
				FontAttributes = FontAttributes.Bold
			};


			var ctrlayout = new StackLayout()
			{
				//HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				Orientation = StackOrientation.Vertical,
				Children = {preBlank, preBlank, preIbu, preAbv }
			};

			return ctrlayout;


		}

		static StackLayout CreateRightSideLayout()
		{

			var beernameLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 15,
				FontAttributes = FontAttributes.Bold
			};
			beernameLabel.SetBinding(Label.TextProperty, "Name");


			var beertypeLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 13,
				FontAttributes = FontAttributes.Italic,
				TextColor = Color.Gray
			};
			beertypeLabel.SetBinding(Label.TextProperty, "Type");

			var ibuLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 11
			};
			ibuLabel.SetBinding(Label.TextProperty, "Ibu");

			var abvLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 11
			};
			abvLabel.SetBinding(Label.TextProperty, "Abv");

			var rslayout = new StackLayout()
			{
				//HorizontalOptions = LayoutOptions.Start,
				//VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
				Children = {beernameLabel, beertypeLabel, ibuLabel, abvLabel }
			};

			return rslayout;
		}

	}
}

