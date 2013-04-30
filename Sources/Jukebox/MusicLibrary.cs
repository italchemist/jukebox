
namespace Jukebox {
	using System.Collections.Generic;
	using Api;

	/// <summary>Music library interface.</summary>
	public sealed class MusicLibrary : IMusicLibrary {
		/// <summary>Returns a collection of tracks satisfying specified query.</summary>
		/// <param name="query">Query.</param>
		/// <returns>Collection of ITrack.</returns>
		public IEnumerable<ITrack> Search(string query) {
			var tracks = new List<ITrack>();
			foreach (var trackProvider in _providers) {
				tracks.AddRange(trackProvider.OnSearch(query));
			}
			return tracks;
		}

		/// <summary>Adds specified provider to the collection.</summary>
		/// <param name="tracksProvider">Provider.</param>
		public void AddTracksProvider(IExtension tracksProvider) {
			_providers.Add(tracksProvider);
		}

		/// <summary>Collection of track providers.</summary>
		private readonly List<IExtension> _providers = new List<IExtension>();
	}
}
