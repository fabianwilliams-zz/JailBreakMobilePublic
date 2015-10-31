using System;
using Newtonsoft.Json;

namespace jbb
{
//	public class Beer
//	{
//		public string Id { get; set; }
//		public string Name { get; set; }
//		public string Type { get; set; }
//		public double Abv { get; set; }
//		public double Ibu { get; set; }
//		public string Taste { get; set; }
//		public string ProName { get; set; }
//		public string Smu {get; set;}
//
//	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class Beer
	{

		public string Id { get; set; }
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }
		[JsonProperty(PropertyName = "abv")]
		public double Abv { get; set; }
		[JsonProperty(PropertyName = "ibu")]
		public double Ibu { get; set; }
		[JsonProperty(PropertyName = "taste")]
		public string Taste { get; set; }
		[JsonProperty(PropertyName = "proname")]
		public string ProName { get; set; }
		[JsonProperty(PropertyName = "smu")]
		public string Smu {get; set;}
		[JsonProperty(PropertyName = "ontapyn")]
		public bool ontapyn { get; set; }
		[JsonProperty(PropertyName = "utbid")]
		public string Utbid { get; set; }

		public override string ToString ()
		{
			return String.Format ("{0}, {1}, {2}, {3}", Name, Type, Abv, Ibu);
		}

	}



	public class MyRootObject
	{
		public Beer[] beers { get; set; }
	}

}

