
namespace Jukebox.Extensions.TrackProviders.VkCom {
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Net;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Threading;
	using Api;
	using Api.OAuth;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;

	/// <summary>Track providers from vk.com.</summary>
	public class VkComTracksProvider : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, IDictionary<string, string> vars) {
			_jukebox = jukebox;
			var t = new Thread(() => OnExtensionThreadStart(jukebox));
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
		}

		/// <summary>Called when extension start.</summary>
		/// <param name="jukebox">The jukebox.</param>
		private void OnExtensionThreadStart(IJukebox jukebox) {
			var oauth = new OAuthAuthentication(new Uri(AuthQueryUri));
			oauth.Navigated += (sender, args) => {
				if (String.IsNullOrEmpty(args.Uri.Fragment)) return;
				var r = new Regex("access_token=(.*)&expires_in");
				_accessToken = r.Match(args.Uri.Fragment).Groups[1].Value;
				jukebox.MusicLibrary.AddTracksProvider(this);
				oauth.Close();
			};
			oauth.Authenicate();
		}

		/// <summary>Called when search requested.</summary>
		/// <param name="query">The query.</param>
		/// <returns>List of the tracks.</returns>
		public override IEnumerable<ITrack> OnSearch(string query) {
			var result      = new List<ITrack>();
			var responseArr = RequestTracksArray(query);

			for (var i = 1; i < responseArr.Count; ++i) {
				var trackData = responseArr[i];
				result.Add(new Track {
					Performer = (string) trackData["artist"],
					Title = (string) trackData["title"],
					Uri = new Uri((string) trackData["url"]),
					Duration = TimeSpan.FromSeconds((Int64) trackData["duration"])
				});
			}
			return result;
		}

		/// <summary>Requests the tracks array.</summary>
		/// <param name="query">The query.</param>
		/// <returns></returns>
		private JContainer RequestTracksArray(string query) {
			var webClient = new WebClient {Encoding = Encoding.UTF8};
			var queryStr = string.Format(CultureInfo.InvariantCulture, AudioQueryUri, query, _accessToken);
			var response = webClient.DownloadString(queryStr);
			var responseContainer = (JContainer) JsonConvert.DeserializeObject(response);
			var tracksArray = (JContainer)responseContainer["response"];
			return tracksArray;
		}

		/// <summary>The jukebox.</summary>
		private IJukebox _jukebox;

		/// <summary>The vk.com access token.</summary>
		private string _accessToken;

		/// <summary>The vk.com authntication url.</summary>
		private const string AuthQueryUri = "https://oauth.vk.com/authorize?response_type=token&redirect_uri=vk.com&client_id=3431166&scope=8&display=popup";

		/// <summary>Audio query uri.</summary>
		private const string AudioQueryUri = "https://api.vk.com/method/audio.search?q={0}&access_token={1}";
	}
}
