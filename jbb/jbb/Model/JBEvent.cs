using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace jbb
{
	public class JBEvent
	{
		public class Creator
		{
			public string email { get; set; }
			public string displayName { get; set; }
		}

		public class Organizer
		{
			public string email { get; set; }
			public string displayName { get; set; }
			public bool self { get; set; }
		}

		public class Start
		{
			//public string dateTime { get; set; }
			public string date { get; set; }
			public string timeZone { get; set; }
		}

		public class End
		{
			public string dateTime { get; set; }
			public string timeZone { get; set; }
		}

		public class Reminders
		{
			public bool useDefault { get; set; }
		}

		public class Item
		{
			public string kind { get; set; }
			public string etag { get; set; }
			public string id { get; set; }
			public string status { get; set; }
			public string htmlLink { get; set; }
			public string created { get; set; }
			public string updated { get; set; }
			public string summary { get; set; }
			public string description { get; set; }
			public string location { get; set; }
			public Creator creator { get; set; }
			public Organizer organizer { get; set; }
			public Start start { get; set; }
			public End end { get; set; }
			public string transparency { get; set; }
			public string iCalUID { get; set; }
			public int sequence { get; set; }
			public Reminders reminders { get; set; }
			public List<string> recurrence { get; set; }
		}

		public class RootObject
		{
			public string kind { get; set; }
			public string etag { get; set; }
			public string summary { get; set; }
			public string description { get; set; }
			public string updated { get; set; }
			public string timeZone { get; set; }
			public string accessRole { get; set; }
			public List<object> defaultReminders { get; set; }
			public string nextSyncToken { get; set; }
			public List<Item> items { get; set; }
			public Item[] eitems { get; set; }
		}

		public class MyEventRootObject
		{
			public List<Item> items { get; set; }
		}

	}
}

