using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace jbb
{
	public class BLCell : ViewCell
	{
		public BLCell ()
		{
			var todoTextLabel = new Label {

				Font = Font.SystemFontOfSize (NamedSize.Medium)
			};
			todoTextLabel.SetBinding (Label.TextProperty, new Binding ("Text"));

			var todoCompleteLabel = new Label {
				Font = Font.SystemFontOfSize (NamedSize.Medium),
				XAlign = TextAlignment.End,
				HorizontalOptions = LayoutOptions.FillAndExpand

			};
			todoCompleteLabel.SetBinding (Label.TextProperty, new Binding ("Complete"));


			View = new StackLayout {
				Children = {todoTextLabel, todoCompleteLabel},
				Orientation = StackOrientation.Horizontal

			};
		}
	}
}

