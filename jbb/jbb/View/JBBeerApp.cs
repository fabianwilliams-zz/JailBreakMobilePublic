using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jbb
{
	public class JBBeerApp : ContentPage
	{

		private BeerService beerService;

		public List<Beer> Items { get; set; }

		public JBBeerApp ()
		{
			beerService = new BeerService ();

			var myCaro = new CarouselPage (new BeerCarousel(Items[0])); 

			this.Content = myCaro;
		}
//
//		public Page GetAllBeer ()
//		{
//
//			beerService = new BeerService ();
//			return new CarouselPage {
//				Title = "Whats on Tap",
//				Children = {
//					new BeerCarousel(ci[0]),
//					new BeerCarousel(ci[1]),
//				}
//			};
//		}
			


		protected async override void OnAppearing()
		{
			base.OnAppearing ();
			await this.RefreshAsync ();
		}

		private async Task RefreshAsync()
		{
			var jbc = new CarouselPage ();
			Items = await beerService.GetAllTodoItems ();
			Title = "Whats on Tap";
			Icon = "xaml.png";

			foreach (var p in Items) {
				jbc.Children.Add (new BeerCarousel (p));
			}
		}
	}
}

