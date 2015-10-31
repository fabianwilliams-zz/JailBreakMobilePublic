using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace jbb
{
	public class JBTeamApp : Application
	//public class JBTeamApp : ContentPage
	{

		public Page GetTeamMembers ()
		{
			
			var jbt = new List<JBTeam> () {
				new JBTeam () {
					Name = "Clay Baines",
					Title = "Brewer",
					Desc = "Clay is our head brewer that can often be  seen from the tasting room in his home away from home, the brewhouse.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/clay-300x300.jpg"
				},
				new JBTeam () { 
					Name = "Taylor Bee",
					Title = "Beer Evangelist",
					Desc = "Bee is for brewing!",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/taylor_cropped.jpg"
				},
				new  JBTeam() { 
					Name = "Justin Bonner",
					Title = "Founder & CEO",
					Desc = "Justin is what’s known as the “wild  card”. He’s opinionated, politically incorrect and likely in need of  therapy.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/justin_new2-e1430598019884-300x300.jpg"
				},
				new JBTeam () { 
					Name = "Jessica Collins",
					Title = "Brand Ambassador",
					Desc = "Jessica, a Jailbreak Brand  Ambassador who also holds a degree in Nursing, has learned that good  beer can be the best medicine.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/jessica2_cropped-300x300.jpg"
				},
				new JBTeam () { 
					Name = "Jennifer Degele",
					Title = "Territory Sales Manager",
					Desc = "Jailbreak's first territory sales manager and resident brewery sweetheart. Always the first and sometimes the only person to laugh at her own jokes.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/jen3-300x300.jpg"
				},
				new JBTeam () { 
					Name = "Ryan Harvey",
					Title = "Brewmaster",
					Desc = "Ryan is the mastermind behind our delicious brews.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/ryan-300x300.jpeg"
				},
				new JBTeam () { 
					Name = "Jake Henry",
					Title = "Beer Evangelist",
					Desc = "As the \"Jake of all trades\" this guy has  conquered everything from Bartender to Sales Rep. He does it all! & Navy Vet.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/jake2-e1430694851995-300x300.jpg"
				},
				new JBTeam () { 
					Name = "Jesse Kaiss",
					Title = "Brewer",
					Desc = "Project manager turned professional brewer, soon to be barley and hops farmer when not working at the brewery, and Dad to 1 year old Audrey.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/jesse_cropped.jpg"
				},
				new JBTeam () { 
					Name = "Tom McGuire",
					Title = "Beer Evangelist",
					Desc = "tmac is the nerd of the group making sure  everyone enjoys their awesome beers responsibly!",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/tom-e1430598497766.png"
				},
				new JBTeam () { 
					Name = "Ross Miller",
					Title = "Brand Ambassador",
					Desc = "Idolizes Fitzgerald, Hemingway, and Bukowski for their iconic drinking careers.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/ross_cropped.jpg"
				},
				new JBTeam () { 
					Name = "Michael Navas",
					Title = "Brewer",
					Desc = "Michael is a man of few words.  Any questions?",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/michael_cropped.jpg"
				},
				new JBTeam () { 
					Name = "Kyle Flynn",
					Title = "Beer Slinger",
					Desc = "Water sucks. Beer is better.",
					PicURL = "http://www.fabiangwilliams.com/wp-content/uploads/2015/08/KyleFlynnBW.jpg"
				},
				new JBTeam () { 
					Name = "Johnny Roye",
					Title = "Beer Evangelist",
					Desc = "Johnny is the strong one, the bearded  muscle behind the beer.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/johnny-300x300.jpg"
				},
				new JBTeam () { 
					Name = "Jim Gemmill",
					Title = "Beer Evangelist",
					Desc = "Jim is probably the realist O.G. at Jailbreak.  Spirit animal is the Honey Badger.  Lives by his mentors creed, \"Mo Money, Mo Problems\"",
					PicURL = "http://jailbreakbrewing.com/wp-content/uploads/2013/01/jim.jpg"
				},
				new JBTeam () { 
					Name = "Elizabeth Shear",
					Title = "Brand Ambassador",
					Desc = "Liz is our social media liaison by  day and outspoken beer consultant by night. Bring her a cookie. She  loves cookies - #allthecookies",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/liz-300x300.jpg"
						
				},
				new JBTeam () { 
					Name = "Erica Turner",
					Title = "Industrial Engineer",
					Desc = "One of our original brewers, Erica  now utilizes her OCD to wrangle the process and paperwork sides of our  brewing operations.",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/erica2-e1430599142154-300x300.png"
				},
				new JBTeam () { 
					Name = "Kasey Turner",
					Title = "Founder & COO",
					Desc = "Kasey is the pragmatic engineer of the  group and lives his life one spreadsheet at a time."
				},
				new JBTeam () { 
					Name = "Gina Mattera",
					Title = "Escape Mastermind",
					Desc = "A mastermind in the kitchen and in event planning, Gina will plan your perfect escape",
					PicURL = "https://jailbreakbrewing.com/wp-content/uploads/2013/01/gina_cropped.jpg"
				},
				new JBTeam () { 
					Name = "Maggie Wear",
					Title = "Lab Wizardess",
					Desc = "Maggie is a social scientist. She runs the lab, if you see her ask her a science question!",
					PicURL = "http://jailbreakbrewing.com/wp-content/uploads/2013/01/maggie.jpg"
				},
			};

				return new CarouselPage {
				Title = "Our Team",
				Icon = "Contacts-30.png",
				Children = { 
					new MeetOurFolks (jbt [0]),
					new MeetOurFolks (jbt [1]),
					new MeetOurFolks (jbt [2]),
					new MeetOurFolks (jbt [3]),
					new MeetOurFolks (jbt [4]),
					new MeetOurFolks (jbt [5]),
					new MeetOurFolks (jbt [6]),
					new MeetOurFolks (jbt [7]),
					new MeetOurFolks (jbt [8]),
					new MeetOurFolks (jbt [9]),
					new MeetOurFolks (jbt [10]),
					new MeetOurFolks (jbt [11]),
					new MeetOurFolks (jbt [12]),
					new MeetOurFolks (jbt [13]),
					new MeetOurFolks (jbt [14]),
					new MeetOurFolks (jbt [15]),
					new MeetOurFolks (jbt [16]),
					new MeetOurFolks (jbt [17])
				}
			};
		}
	}
}

