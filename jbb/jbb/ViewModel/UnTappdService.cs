using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleAuth;
using SimpleAuth.OAuth;
//using SimpleAuth.Providers;
using Xamarin.Forms;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace jbb
{

	public class UnTappdService
	{
		OAuthApi api;
		public UnTappdService ()
		{

		}

		public async Task<OAuthAccount> GetUntappdTokenAsync()
		{

			try
			{
				var account = (await api.Authenticate(new string[]{"openid"})) as OAuthAccount ;
				Console.WriteLine(account.Token);
				return account;
			}
			catch (TaskCanceledException ex)
			{
				Console.WriteLine("Canceled");
				return null;
			}



		}
			
	}

	public class untappdAuthenticator : OAuthAuthenticator {

		public untappdAuthenticator (string authUrl, string tokenUrl,string redirectUrl, string clientId, string clientSecret)
			:base(authUrl, tokenUrl, redirectUrl, clientId, clientSecret)
		{}

		public override async Task<Uri> GetInitialUrl()
		{
			var scope = string.Join("%20", Scope.Select(HttpUtility.UrlEncode));
			var delimiter = BaseUrl.EndsWith ("?", StringComparison.CurrentCultureIgnoreCase) ? "" : "?";
			var url = $"{BaseUrl}{delimiter}client_id={ClientId}&scope={scope}&response_type=token&redirect_url={RedirectUrl.AbsoluteUri}";
			return new Uri(url);
		}

		public override bool CheckUrl(Uri url, Cookie[] cookies)
		{
			try
			{
				if (url == null || string.IsNullOrWhiteSpace(url.Fragment))
					return false;
				if (url.Host != RedirectUrl.Host)
					return false;
				var parts = HttpUtility.ParseQueryString(url.Fragment.Substring(1));
				var code = parts["access_token"];
				if (!string.IsNullOrWhiteSpace(code)){
					FoundAuthCode(code);
					return true;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return false;
		}

	}

	public class untappedApi : OAuthApi {

		public untappedApi (string Identifier, untappdAuthenticator Authenticator) : base (Identifier, Authenticator)
		{
		}

		protected override async Task<OAuthAccount> GetAccountFromAuthCode(Authenticator authenticator, string identifier)
		{
			var account = new OAuthAccount()
			{
				ExpiresIn = (long)(TimeSpan.FromDays(365).TotalSeconds),
				Created = DateTime.UtcNow,
				TokenType = "Bearer",
				Token = authenticator.AuthCode,
				ClientId = ClientId,
				Identifier = identifier,
			};
			return account;
		}

	}
}

