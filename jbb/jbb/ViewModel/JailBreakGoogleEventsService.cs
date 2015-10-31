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
	public class JailBreakGoogleEventsService
	{


		public JailBreakGoogleEventsService ()
		{
		}
		public async Task<JBEvent.RootObject> GetJBEventsAsync () {

			var client = new System.Net.Http.HttpClient ();
			var requestMessage = new HttpRequestMessage()
			{
				
				RequestUri = new Uri("YOUR URI END POINT FOR WEB API FOR GOOGLE CALENDAR"),
				Method = HttpMethod.Get,
			};

			var response = await client.SendAsync (requestMessage);
			var eventJson = response.Content.ReadAsStringAsync().Result;
			var rootobject = JsonConvert.DeserializeObject<JBEvent.RootObject>(eventJson);


			return rootobject;



		}

		public async Task<JBEvent.RootObject> GetJBFoodTrucksAsync () {
			var client = new System.Net.Http.HttpClient ();
			var requestMessage = new HttpRequestMessage()
			{
				RequestUri = new Uri("YOUR URI END POINT FOR WEB API FOR GOOGLE CALENDAR"),
				Method = HttpMethod.Get,
			};

			var response = await client.SendAsync (requestMessage);
			var eventJson = response.Content.ReadAsStringAsync().Result;
			var rootobject = JsonConvert.DeserializeObject<JBEvent.RootObject>(eventJson);

			return rootobject;



		}

	}
}

