
namespace Jukebox.Extensions.Interfaces.Web {
	using System.IO;
	using Api;
	using Nancy;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;
	using ResponseModels;

	/// <summary>Welcome module.</summary>
	public class WelcomeModule : NancyModule {
		/// <summary>Initializes a new instance of the <see cref="WelcomeModule"/> class.</summary>
		public WelcomeModule() {
			Get["/"] = x => GetPage(PageResources.IndexPage, "index.html");
			
			Get["/tracks/search/{query}"] = x => {
				var tracks = Config.Jukebox.MusicLibrary.Search(x.query);
				var responseData = new SearchTracksResponse();
				foreach (ITrack track in tracks) {
					responseData.Tracks.Add(new TrackResponse(Config.Jukebox.MusicLibrary.GetCacheId(track), track.Performer, track.Title));
				}
				return GetJson(responseData);
			};

			Post["/tracks/enqueue"] = x => {
				using (var a = new StreamReader(Request.Body)) {
					var data = a.ReadToEnd();
					dynamic d2 = JsonConvert.DeserializeObject(data);
					var trackId = d2.trackId.ToString();

					//				var a = new JsonTextReader(Request.Body);
					//using (var s = new StringReader(Request.Body)) {

					//}
					var track = Config.Jukebox.MusicLibrary.GetTrackFromCache(trackId);
					// TODO: IF track not found
					Config.Jukebox.MusicLibrary.SetTrackState(track, TrackState.Download);
					Config.Jukebox.Playlist.Enqueue(track);
					var response = (Response) (JsonConvert.SerializeObject(
						new OperationResponse(track != null), Formatting.None,
						new JsonSerializerSettings {
							ContractResolver = new CamelCasePropertyNamesContractResolver()
						}));
					response.ContentType = JsonContentType;
					return response;
				}
			};

			/*String.Format(PageResources.IndexPage, Config.Title, Config.Message, Config.StreamPath);*/
		}

		public Response GetJson(object data) {
			var response = (Response) JsonConvert.SerializeObject(data, Formatting.None, JsonSerializerSettings);
			response.ContentType = JsonContentType;
			return response;			
		}

		public string GetPage(string stored, string file) {
			return File.Exists(file) ? File.ReadAllText(file) : stored;
		}

		/// <summary>The json content type.</summary>
		private const string JsonContentType = "application/json";

		private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings {
			ContractResolver = new CamelCasePropertyNamesContractResolver()
		};
	}
}
