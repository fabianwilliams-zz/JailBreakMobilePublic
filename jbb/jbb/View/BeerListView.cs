using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jbb
{
	public class BeerListView : ContentPage
	{
		private ListView listView;

		public List<Beer> Items { get; private set; }

		private BeerListViewViewModel ViewModel { get; set; }

		public BeerListView ()
		{
			// you need a view model to bind to

			// setup your ViewModel

			ViewModel = new BeerListViewViewModel
			{
				
			};
			// Set the binding context to the newly created ViewModel
			BindingContext = ViewModel;

			listView = new ListView {
//				HasUnevenRows = true

			};

			//need to add a Details Push Event on the ITemSelected here when working done
			listView.ItemSelected += (sender, e) => {
				Navigation.PushAsync(new BeerDetail(e.SelectedItem as Beer));
			};

			var activityIndicator = new ActivityIndicator
			{
				Color = Color.Black,
			};
			activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
			activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");


			this.Title = "All our Beers on Tap";
			this.Content = new StackLayout {
				Padding = new Thickness (0, Device.OnPlatform (0, 0, 0), 0, 0),
				Spacing = 3,
				Orientation = StackOrientation.Vertical,
				Children = {
					activityIndicator,listView
				}
			};

		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{
			ViewModel.IsBusy = true;
			var jbms = new BeerListViewViewModel();
			var gba = await jbms.GetBeersAsync();
			ViewModel.IsBusy = false;
			listView.ItemsSource = gba;

			// configure the pull-to-refresh
			listView.IsPullToRefreshEnabled = true;
			listView.RefreshCommand = ViewModel.LoadBeersCommand;
			listView.IsRefreshing = ViewModel.IsBusy;
			listView.SetBinding(ListView.IsRefreshingProperty, "IsBusy");
			listView.SetBinding<BeerListViewViewModel>(ListView.IsRefreshingProperty, vm => vm.IsBusy, mode: BindingMode.OneWay);


			//var cell = new DataTemplate (typeof(TextCell));
			//use the two lines below if you want to use the default text property
			//cell.SetBinding(TextCell.TextProperty, "Name"); //the word Text here represents the field in the Database we want returned
			//listView.ItemTemplate = cell;
			//end two lines commentary

			listView.ItemTemplate = new DataTemplate (typeof(ListOfBeerCell2)); //this uses my customized cell to make 2 items in 1 row


		}
	}
}

