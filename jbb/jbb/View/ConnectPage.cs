using System;

using Xamarin.Forms;

namespace jbb
{
	public class ConnectPage : ContentPage
	{
		
		public ConnectPage ()
		{
			
			Title = "Get in touch";

			var addrLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Gray,
				Text = "Address",
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			var addrDetLabel = new Label {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Small),
				Text = "9445 Washington Blvd N, STE F"
			};

			var addrDetCityStateLabel = new Label {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Small),
				Text = "Laurel, MD 20723"
			};

			var phoneLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "Phone",
				BackgroundColor = Color.Gray,
				Font = Font.SystemFontOfSize(NamedSize.Micro)
			};

			var phoneButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "Call Us"
			};

			var bookEventLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "Book the Taproom for Your Event",
				BackgroundColor = Color.Gray,
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};

			var emailEventButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "Book Your Next Event"
			};

			var requestCharityLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "Ask for a Charitable Donation",
				BackgroundColor = Color.Gray,
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};

			var charityReqButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "Request a Donation"
			};

			var genInfoLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "General Info Request",
				BackgroundColor = Color.Gray,
				Font = Font.SystemFontOfSize(NamedSize.Small)
			};

			var genInfoButton = new Button {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Text = "Email Us"
			};

			var meetTeamButton = new Button () {
				//HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BackgroundColor = Color.Black,
				TextColor = Color.White,
				Text = "Meet our Team"
			};

			meetTeamButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new JBTeamAppV2().GetTeamMembers());
				};

			phoneButton.Clicked += (sender, e) => {
				Device.OpenUri(new Uri("tel:443-345-9699"));
			};

			emailEventButton.Clicked += (sender, e) => {
				Device.OpenUri(new Uri("mailto:reservations@jailbreakbrewing.com"));
			};

			charityReqButton.Clicked += (sender, e) => {
				Device.OpenUri(new Uri("https://jailbreakbrewing.com/charity-requests/"));
			};

			genInfoButton.Clicked += (sender, e) => {
				Device.OpenUri(new Uri("mailto:info@jailbreakbrewing.com"));
			};

			Content = new StackLayout { 
				Spacing = 3,
				Children = {
					addrLabel,
					addrDetLabel,
					addrDetCityStateLabel,
					phoneLabel,
					phoneButton,
					bookEventLabel,
					emailEventButton,
					requestCharityLabel,
					charityReqButton,
					genInfoLabel,
					genInfoButton,
					meetTeamButton
				}
			};
		}
	}
}


