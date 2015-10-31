using System;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace jbb
{
	public class JailBreakBeerMongoService : BaseViewModel
	{


		public async Task<Beer[]> GetBeersAsync () {
			//above was <Beer[]>
			var client = new System.Net.Http.HttpClient ();
			var requestMessage = new HttpRequestMessage()
			{
				RequestUri = new Uri("YOUR URI END POINT FOR WEB API"),
				Method = HttpMethod.Get,
			};

			requestMessage.Headers.Add("Ocp-Apim-Trace", "true");
			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "YOUR KEY HERE");

			var response = await client.SendAsync (requestMessage);
			var beerJson = "{\"beers\":" + response.Content.ReadAsStringAsync().Result + "}";
			var rootobject = JsonConvert.DeserializeObject<MyRootObject>(beerJson);
			//var rootobject = JsonConvert.DeserializeObject<List<RootBeers>>(beerJson);
			//List<Beer> rootobject = (Beer)Newtonsoft.Json.JsonConvert.DeserializeObject(beerJson, typeof(Beer));


			return rootobject.beers;


		}

		public async Task<Beer[]> GetOnTapBeersAsync () {

			var client = new System.Net.Http.HttpClient ();

			var requestMessage = new HttpRequestMessage()
			{
				RequestUri = new Uri("YOUR URI END POINT FOR WEB API"),

				Method = System.Net.Http.HttpMethod.Get,
			};

			requestMessage.Headers.Add("Ocp-Apim-Trace", "true");
			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", "YOUR API KEY");

			var response = await client.SendAsync (requestMessage);
			var beerJson = "{\"beers\":" + response.Content.ReadAsStringAsync().Result + "}";
			var rootobject = JsonConvert.DeserializeObject<MyRootObject>(beerJson);
			//var rootobject = JsonConvert.DeserializeObject<List<RootBeers>>(beerJson);
			//List<Beer> rootobject = (Beer)Newtonsoft.Json.JsonConvert.DeserializeObject(beerJson, typeof(Beer));


			return rootobject.beers;


		}

	}
}

