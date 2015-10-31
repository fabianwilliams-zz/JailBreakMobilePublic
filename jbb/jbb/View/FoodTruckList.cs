using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jbb
{
	public class FoodTruckList : ContentPage
	{

		public event EventHandler Refreshing; 
		public bool IsPullToRefreshEnabled { get; set; } = false; 
		public bool IsRefreshing { get; set; } = false; 
		public Command RefreshCommand { get; set; } = null; 

		private BeerListViewViewModel ViewModel { get; set; }

		ListView lv;
		List<JBEvent.Item>currandfut = new List<JBEvent.Item>();
		int i = 0;

		public FoodTruckList ()
		{


			ViewModel = new BeerListViewViewModel
			{

			};
			// Set the binding context to the newly created ViewModel
			BindingContext = ViewModel;


			Title = "Food Truck Schedule";

			lv = new ListView (
//				IsPullToRefreshEnabled = true,
//				RefreshCommand = {Binding IsBusy, Mode=OneWay},
//				IsRefreshing = ""

			);

			//var cell = new DataTemplate (typeof(TextCell));
			//use the two lines below if you want to use the default text property
			//cell.SetBinding(TextCell.TextProperty, "summary"); //the word Text here represents the field in the Database we want returned
			//lv.ItemTemplate = cell;
			//end two lines commentary

			lv.ItemTemplate = new DataTemplate (typeof(JBEventCell)); 

			lv.ItemSelected += (sender, e) => {
				Navigation.PushAsync(new EventDetails(e.SelectedItem as JBEvent.Item));
			};

			Content = new StackLayout { 
				Padding = new Thickness (0, Device.OnPlatform (0, 0, 0), 0, 0),
				Spacing = 3,
				Orientation = StackOrientation.Vertical,
				Children = {
					lv
				}
			};
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.CallJBGoogleCalendarAsync ();
		}

		public async Task CallJBGoogleCalendarAsync ()
		{
			var jbges = new JailBreakGoogleEventsService();
			var gba = await jbges.GetJBFoodTrucksAsync();
			while (i < gba.items.Count) {
				DateTime checkVal = Convert.ToDateTime (gba.items [i].start.date);
				if (checkVal >= DateTime.Now.Subtract(TimeSpan.FromDays(1))) {
					currandfut.Add(gba.items[i]);
				}
				i++;
			}

			lv.ItemsSource = currandfut.OrderBy(o=>o.start.date).ToList();
		}
	}
}

