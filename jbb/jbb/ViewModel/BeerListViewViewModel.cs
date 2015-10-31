using System;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jbb
{
	public class BeerListViewViewModel : BaseViewModel
	{
		private HttpResponseMessage _rawJSONText;

		public HttpResponseMessage RawJSONText
		{
			get { return _rawJSONText; }
			set
			{
				_rawJSONText = value;
				OnPropertyChanged();
			}
		}

		public async Task<Beer[]> GetBeersAsync () {
			//above was <Beer[]>
			var client = new System.Net.Http.HttpClient ();
			var requestMessage = new HttpRequestMessage()
			{
				RequestUri = new Uri("https://fabianooc.azure-api.net/breakin/Beer"),
				Method = HttpMethod.Get,
			};

			requestMessage.Headers.Add("Ocp-Apim-Trace", "true");
			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "dfda3434dd624baaa88f7e6fada83524");

			RawJSONText = await client.SendAsync (requestMessage);
			var beerJson = "{\"beers\":" + RawJSONText.Content.ReadAsStringAsync().Result + "}";
			var rootobject = JsonConvert.DeserializeObject<MyRootObject>(beerJson);
			//var rootobject = JsonConvert.DeserializeObject<List<RootBeers>>(beerJson);
			//List<Beer> rootobject = (Beer)Newtonsoft.Json.JsonConvert.DeserializeObject(beerJson, typeof(Beer));


			return rootobject.beers;


		}

		public async Task<Beer[]> GetOnTapBeersAsync () {

			var client = new System.Net.Http.HttpClient ();

			var requestMessage = new HttpRequestMessage()
			{
				RequestUri = new Uri("https://fabianooc.azure-api.net/breakin/GetWhatsOnTap"),

				Method = System.Net.Http.HttpMethod.Get,
			};

			requestMessage.Headers.Add("Ocp-Apim-Trace", "true");
			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "dfda3434dd624baaa88f7e6fada83524");

			RawJSONText = await client.SendAsync (requestMessage);
			var beerJson = "{\"beers\":" + RawJSONText.Content.ReadAsStringAsync().Result + "}";
			var rootobject = JsonConvert.DeserializeObject<MyRootObject>(beerJson);
			//Console.WriteLine (rootobject);
			//var rootobject = JsonConvert.DeserializeObject<List<RootBeers>>(beerJson);
			//List<Beer> rootobject = (Beer)Newtonsoft.Json.JsonConvert.DeserializeObject(beerJson, typeof(Beer));


			return rootobject.beers;


		}

		public async Task<MyStaffRootObject> GetAllStaffAsync () {

			var client = new System.Net.Http.HttpClient ();

			var requestMessage = new HttpRequestMessage()
			{
				RequestUri = new Uri("https://fabianooc.azure-api.net/breakin/Staff"),

				Method = System.Net.Http.HttpMethod.Get,
			};

			requestMessage.Headers.Add("Ocp-Apim-Trace", "true");
			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "dfda3434dd624baaa88f7e6fada83524");

			RawJSONText = await client.SendAsync (requestMessage);
			var staffJson = "{\"staffs\":" + RawJSONText.Content.ReadAsStringAsync().Result + "}";
			var rootobject = JsonConvert.DeserializeObject<MyStaffRootObject>(staffJson);
			//Console.WriteLine (rootobject);
			//var rootobject = JsonConvert.DeserializeObject<List<RootBeers>>(beerJson);
			//List<Beer> rootobject = (Beer)Newtonsoft.Json.JsonConvert.DeserializeObject(beerJson, typeof(Beer));


			return rootobject;


		}



		private Command loadBeersCommand;

		public Command LoadBeersCommand 
		{
			get 
			{ 
				return loadBeersCommand ?? (loadBeersCommand = new Command (ExecuteLoadBeersCommand, ()=>
					{
						return !IsBusy;
					})); 
			}
		}

		private async void ExecuteLoadBeersCommand ()
		{
			if (IsBusy)
				return;

			IsBusy = true;
			 LoadBeersCommand.ChangeCanExecute();
				
			//To-do -- add code

			IsBusy = false;
			 LoadBeersCommand.ChangeCanExecute();
		}
	}
}

