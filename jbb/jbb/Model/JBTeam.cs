using System;

namespace jbb
{
	public class JBTeam
	{
		public string Name { get; set;}
		public string Title { get; set;}
		public string Desc { get; set;}
		public string PicURL { get; set;}

		public override string ToString ()
		{
			return String.Format ("{0}, {1}, {2}, {3}", Name, Title, Desc, PicURL);
		}

	}



	public class MyStaffRootObject
	{
		public JBTeam[] staffs { get; set; }
	}
}

