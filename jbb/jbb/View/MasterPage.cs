using System;
using Xamarin.Forms;

namespace jbb
{
	public class MasterPage : TabbedPage
	{
		public MasterPage ()
		{
			this.Children.Add (new BeerListView () {Title = "All Beers", Icon = "Beer-30.png"});
			this.Children.Add (new WhatsOnTapPage () {Title = "What's On Tap", Icon = "BeerGlass-30.png"});
			this.Children.Add (new FoodTruckList () { Title = "Food Trucks", Icon = "Truck-30.png" });
			this.Children.Add (new JBEventsPage () {Title = "Events", Icon = "Calendar-30.png"});
			this.Children.Add (new ConnectPage () { Title = "Connect", Icon = "Meeting-30.png" });
		}
	}
}

