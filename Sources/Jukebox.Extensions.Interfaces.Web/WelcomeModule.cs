
namespace Jukebox.Extensions.Interfaces.Web {
	using Nancy;

	/// <summary>Welcome module.</summary>
	public class WelcomeModule : NancyModule {
		/// <summary>Initializes a new instance of the <see cref="WelcomeModule"/> class.</summary>
		public WelcomeModule() {
			Get["/"] = x => PageResources.IndexPage;
			Get["/tracks/list"] = x => {
				var response = (Response) "{ \"test\": \"123\" }";
				response.ContentType = JsonContentType;
				return response;
			};
			/*String.Format(PageResources.IndexPage, Config.Title, Config.Message, Config.StreamPath);*/
		}

		private const string JsonContentType = "application/json";
	}
}
