using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace jbb
{
	public class BLCellwImage : ViewCell
	{
		public BLCellwImage ()
		{
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Start
			};
			image.SetBinding(Image.SourceProperty, new Binding("ProName"));
			//image.WidthRequest = 100;
			//image.HeightRequest = 40;

			var namedisplayl = new Label {
				Text = "Type: "
			};

			var nameLayout = CreateNameLayout();

			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { image, namedisplayl, nameLayout }
			};
			View = viewLayout;
		}

		static StackLayout CreateNameLayout()
		{


			var nameLabel = new Label
			{
				HorizontalOptions= LayoutOptions.FillAndExpand
			};
			nameLabel.SetBinding(Label.TextProperty, "Type");


			var ibuLabel = new Label
			{
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			ibuLabel.SetBinding(Label.TextProperty, "Ibu");

			var nameLayout = new StackLayout()
			{
				//HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = {nameLabel }
			};
			return nameLayout;
		}
	}
}

