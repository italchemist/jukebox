
namespace Jukebox.Extensions.Interfaces.Web.ResponseModels {
	/// <summary>Track response.</summary>
	class TrackResponse {
		/// <summary>Initializes a new instance of the <see cref="TrackResponse"/> class.</summary>
		/// <param name="id">The artist.</param>
		/// <param name="artist">The artist.</param>
		/// <param name="title">The title.</param>
		public TrackResponse(string id, string artist, string title) {
			Id = id;
			Artist = Escape(artist);
			Title = Escape(title);
		}

		/// <summary>Gets the id.</summary>
		public string Id { get; private set; }

		/// <summary>Gets the artist.</summary>
		public string Artist { get; private set; }

		/// <summary>Gets the title.</summary>
		public string Title { get; private set; }

		/// <summary>Escapes the specified string.</summary>
		/// <param name="txt">The string.</param>
		/// <returns>Escaped string.</returns>
		private static string Escape(string txt) {
			// TODO: rewrite
			return txt.Replace('\"', '\'').Replace('\n', ' ').Replace('\r', ' ').Replace('\t', ' ');
		}
	}
}