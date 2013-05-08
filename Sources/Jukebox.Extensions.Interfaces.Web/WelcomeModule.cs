
namespace Jukebox.Extensions.Interfaces.Web {
	using Api;
	using Nancy;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;
	using ResponseModels;

	/// <summary>Welcome module.</summary>
	public class WelcomeModule : NancyModule {
		/// <summary>Initializes a new instance of the <see cref="WelcomeModule"/> class.</summary>
		public WelcomeModule() {
			Get["/"] = x => {
				JukeboxApplication.Log.Write("Index page access.");
				return PageResources.IndexPage;
			};
			
			Get["/tracks/search/{query}"] = x => {
				JukeboxApplication.Log.WriteFormat("Search query {0}", x.query);
				var tracks = Config.Jukebox.MusicLibrary.Search(x.query);
				var responseData = new SearchTracksResponse();

				foreach (ITrack track in tracks ) {
					responseData.Tracks.Add(new TrackResponse(track.Performer, track.Title));
				}

				var response = (Response)(JsonConvert.SerializeObject(responseData, Formatting.None, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
				response.ContentType = JsonContentType;
				return response;
			};
			/*String.Format(PageResources.IndexPage, Config.Title, Config.Message, Config.StreamPath);*/
		}

		/// <summary>The json content type.</summary>
		private const string JsonContentType = "application/json";
	}
}
