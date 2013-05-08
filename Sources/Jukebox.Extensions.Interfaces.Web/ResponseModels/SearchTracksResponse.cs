
namespace Jukebox.Extensions.Interfaces.Web.ResponseModels {
	using System.Collections.Generic;

	/// <summary>Search tracks respose.</summary>
	sealed class SearchTracksResponse {
		/// <summary>Initializes a new instance of the <see cref="SearchTracksResponse"/> class.</summary>
		public SearchTracksResponse() {
			Tracks = new List<TrackResponse>();
		}
		
		/// <summary>Gets or sets the tracks.</summary>
		public List<TrackResponse> Tracks { get; set; }
	}
}