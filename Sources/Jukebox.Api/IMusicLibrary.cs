
namespace Jukebox.Api {
	using System.Collections.Generic;

	/// <summary>Music library interface.</summary>
	public interface IMusicLibrary {
		/// <summary>Returns a collection of tracks satisfying specified query.</summary>
		/// <param name="query">Query.</param>
		/// <returns>Collection of ITrack.</returns>
		IEnumerable<ITrack> Search(string query);

		/// <summary>Adds specified provider to the collection.</summary>
		/// <param name="tracksProvider">Provider.</param>
		void AddTracksProvider(IExtension tracksProvider);
	}
}
