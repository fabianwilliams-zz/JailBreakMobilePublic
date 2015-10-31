using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;
#if __IOS__
using UIKit;
using Xam.Plugin.MapExtend.iOSUnified;
#elif __ANDROID__
using Mono;
#endif
using Xamarin.Media;
using Xamarin.Social.Services;
using Xamarin.Social;

namespace jbb
{
	public class EventDetails : ContentPage
	{


		public EventDetails (JBEvent.Item jbe)
		{
			Padding = new Thickness (10, Device.OnPlatform (10,10, 10), 10, 0);

			var startLabel = new Label () {
				Text = "Start: ",
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var endLabel = new Label () {
				Text = "End: ",
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var startLabelData = new Label () {
				Text = jbe.start.date,
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			var endLabelData = new Label () {
				Text = jbe.end.dateTime,
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			var summary = new Label () {
				FontAttributes = FontAttributes.Bold,
				Text = jbe.summary,
				Font = Font.SystemFontOfSize(NamedSize.Medium)
			};

			var desc = new Label () {
				Text = jbe.description,
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			var htmlLink = new Label () {
				Text = jbe.htmlLink,
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			var loc = new Label () {
				Text = jbe.location,
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			Content = new ScrollView {
				Content = new StackLayout {
					Spacing = 10,
					Children = {startLabelData, endLabelData, summary, desc}
				}
			};
		}
	}
}

