using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jbb
{
	public class WhatsOnTapPage : ContentPage
	{

		ListView lv;
		private BeerListViewViewModel ViewModel { get; set; }

		public WhatsOnTapPage ()
		{
			ViewModel = new BeerListViewViewModel
			{

			};
			// Set the binding context to the newly created ViewModel
			BindingContext = ViewModel;

			Title = "Whats On Tap Today";

			lv = new ListView ();

			lv.ItemTemplate = new DataTemplate (typeof(ListOfBeerCell2)); 

			lv.ItemSelected += (sender, e) => {
				Navigation.PushAsync(new BeerDetail(e.SelectedItem as Beer));
			};
					
			var activityIndicator = new ActivityIndicator
			{
				Color = Color.Black,
			};
			activityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
			activityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");



			Content = new StackLayout { 
				Padding = new Thickness (0, Device.OnPlatform (0, 0, 0), 0, 0),
				Spacing = 3,
				Orientation = StackOrientation.Vertical,
				Children = {
					activityIndicator,lv
				}
			};

		}

		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.CallMongoDatabaseAsync ();
		}

		public async Task CallMongoDatabaseAsync()
		{
			var jbms = new BeerListViewViewModel();
			ViewModel.IsBusy = true;
			var gba = await jbms.GetOnTapBeersAsync();
			ViewModel.IsBusy = false;
			lv.ItemsSource = gba;

			// configure the pull-to-refresh
			lv.IsPullToRefreshEnabled = true;
			lv.RefreshCommand = ViewModel.LoadBeersCommand;
			lv.IsRefreshing = ViewModel.IsBusy;
			lv.SetBinding(ListView.IsRefreshingProperty, "IsBusy");
			lv.SetBinding<BeerListViewViewModel>(ListView.IsRefreshingProperty, vm => vm.IsBusy, mode: BindingMode.OneWay);

		}

	}
}

