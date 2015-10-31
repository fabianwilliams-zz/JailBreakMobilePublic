using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace jbb
{
	public class JBEventCell : ViewCell
	{
		public JBEventCell ()
		{
			var summaryLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 13,
				FontAttributes = FontAttributes.Bold
			};
			summaryLabel.SetBinding(Label.TextProperty, "summary");

			var moreAction = new MenuItem { Text = "More" };
			moreAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			moreAction.Clicked += async (sender, e) => {
				var mi = ((MenuItem)sender);
				Debug.WriteLine("More Context Action clicked: " + mi.CommandParameter);

			};
			var deleteAction = new MenuItem { Text = "Add Me", IsDestructive = true }; // red background
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			deleteAction.Clicked += async (sender, e) => {
				var mi = ((MenuItem)sender);
				Debug.WriteLine("Add To Calendar Action clicked: " + mi.CommandParameter);
			};
			// add to the ViewCell's ContextActions property
			ContextActions.Add (moreAction);
			ContextActions.Add (deleteAction);



			var ctrlayout = CreateMiddleSide ();

			var rghtlayout = CreateRightSide ();

			var leftImageLayout = new StackLayout()
			{
				//Spacing = 2,
				Padding = new Thickness (5, 5, 0, 5),
				VerticalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Vertical,
				Children = {summaryLabel, rghtlayout}
			};
			View = leftImageLayout;
		}

		static StackLayout CreateMiddleSide()
		{
			var sLabel = new Label () {
				Text = "Start: ",
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};
//
//			var eLabel = new Label () {
//				Text = "End: ",
//				Font = Font.SystemFontOfSize(NamedSize.Micro)
//			};
//
			var ctrlayout = new StackLayout()
			{
				//HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
				Children = {sLabel }
			};

			return ctrlayout;
		}

		static StackLayout CreateRightSide()
		{
			var startLabel = new Label
			{
				HorizontalOptions= LayoutOptions.StartAndExpand,
				FontSize = 11,
				//FontAttributes = FontAttributes.Bold
			};
			startLabel.SetBinding(Label.TextProperty, "start.date");
//
//			var endLabel = new Label
//			{
//				//HorizontalOptions= LayoutOptions.StartAndExpand,
//				FontSize = 11,
//				//FontAttributes = FontAttributes.Italic,
//				//TextColor = Color.Gray
//			};
//			endLabel.SetBinding(Label.TextProperty, "end.dateTime");

			var rslayout = new StackLayout()
			{
				VerticalOptions = LayoutOptions.Start,
				Orientation = StackOrientation.Vertical,
				Children = {startLabel}
			};

			return rslayout;
		}
	}
}

