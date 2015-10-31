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
				//RequestUri = new Uri("https://www.googleapis.com/calendar/v3/calendars/q1k3ll0bdkis2ceef447rthocs@group.calendar.google.com/events?key=AIzaSyAHLnznypEgj3IAWmDe04XCBpSqgKhikP4"),
				RequestUri = new Uri("https://www.googleapis.com/calendar/v3/calendars/jailbreakbrewing.com_gqdh070qj7ajjt6rmas6ca5ju0@group.calendar.google.com/events?key=AIzaSyAHLnznypEgj3IAWmDe04XCBpSqgKhikP4"),
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
				RequestUri = new Uri("https://www.googleapis.com/calendar/v3/calendars/jailbreakbrewing.com_upiufesmmavkpud9t448q9i4q4@group.calendar.google.com/events?key=AIzaSyAHLnznypEgj3IAWmDe04XCBpSqgKhikP4"),
				Method = HttpMethod.Get,
			};

			var response = await client.SendAsync (requestMessage);
			var eventJson = response.Content.ReadAsStringAsync().Result;
			var rootobject = JsonConvert.DeserializeObject<JBEvent.RootObject>(eventJson);

			return rootobject;



		}

	}
}

