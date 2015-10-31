using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace jbb
{
	public class JBTeamAppV2 : Application
	//public class JBTeamApp : ContentPage
	{
		CarouselPage mcp = new CarouselPage();

		private async Task RefreshAsync()
		{
			var staffSvc = new BeerListViewViewModel();
			var currStaff = await staffSvc.GetAllStaffAsync();
			mcp.Title = "Our Team";
			mcp.Icon = "Contacts-30.png";

			foreach (var s in currStaff.staffs) {
				var jbt = new JBTeam () {
					Name = s.Name,
					Title = s.Title,
					Desc = s.Desc,
					PicURL = s.PicURL
				};
				mcp.Children.Add (new MeetOurFolks(jbt));
			}

		}


		public Page GetTeamMembers ()
		{
			RefreshAsync ();
			return mcp;
		}
	}
}

