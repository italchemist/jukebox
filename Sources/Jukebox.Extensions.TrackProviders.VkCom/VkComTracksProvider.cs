
namespace Jukebox.Extensions.TrackProviders.VkCom {
	using System;
	using System.Collections.Generic;
	using System.Net;
	using System.Text;
	using System.Threading;
	using System.Windows.Forms;
	using Api;

	/// <summary>Track providers from vk.com.</summary>
	public class VkComTracksProvider : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, IDictionary<string, string> vars) {
			var t = new Thread(() => OnExtensionThreadStart(jukebox));
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
		}

		/// <summary>Called when extension start.</summary>
		/// <param name="jukebox">The jukebox.</param>
		private void OnExtensionThreadStart(IJukebox jukebox) {
			Application.EnableVisualStyles();
			var form = new AuthenticationForm();
			Application.Run(form);
			_accessToken = form.AccessToken;
			jukebox.MusicLibrary.AddTracksProvider(this);
		}

		/// <summary>Called when search requested.</summary>
		/// <param name="query">The query.</param>
		/// <returns>List of the tracks.</returns>
		public override IEnumerable<ITrack> OnSearch(string query) {
			var result      = new List<ITrack>();
			var responseArr = RequestTracksArray(query);

			for (var i = 1; i < responseArr.Count; ++i) {
				var trackData = (JsonObject)responseArr[i];
				result.Add(new Track {
					Performer = (string)trackData["artist"],
					Title     = (string)trackData["title"],
					Uri       = new Uri((string)trackData["url"]),
					State     = TrackState.Download,
					Duration  = TimeSpan.FromSeconds((Int64)trackData["duration"])
				});
			}
			return result;
		}

		/// <summary>Requests the tracks array.</summary>
		/// <param name="query">The query.</param>
		/// <returns></returns>
		private JsonArray RequestTracksArray(string query) {
			var webClient = new WebClient {Encoding = Encoding.UTF8};
			var queryStr = string.Format("https://api.vk.com/method/audio.search?q={0}&access_token={1}", query, _accessToken);
			var response = webClient.DownloadString(queryStr);
			var responseObj = (JsonObject) SimpleJson.DeserializeObject(response);
			var responseArr = (JsonArray) responseObj["response"];
			return responseArr;
		}

		/// <summary>The vk.com access token.</summary>
		private string _accessToken;
	}
}
