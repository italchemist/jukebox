
namespace Jukebox {
	using System;
	using System.Collections.Generic;
	using Api;

	/// <summary>Music library.</summary>
	public sealed class MusicLibrary : IMusicLibrary {
		/// <summary>Ges the state of the track.</summary>
		/// <param name="track">The track.</param>
		/// <returns>State of the track.</returns>
		public TrackState GeTrackState(ITrack track) {
			TrackState state;
			return _state.TryGetValue(track, out state) ? state : TrackState.Unknown;
		}

		/// <summary>Sets the state of the track.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		public void SetTrackState(ITrack track, TrackState state) {
			_state[track] = state;
			var evnt = TrackStateChanged;
			if (evnt != null) evnt(this, new MusicLibraryEventArgs(track, state));
		}

		/// <summary>Gets cache id of the specified track.</summary>
		/// <param name="track">The track.</param>
		/// <returns>Cache Id.</returns>
		public string GetCacheId(ITrack track) {
			return _cache.GetCacheId(track);
		}

		/// <summary>Gets the track by specified track id.</summary>
		/// <param name="trackId">The track id.</param>
		/// <returns>Track. Null if nothing found.</returns>
		public ITrack GetTrackFromCache(string trackId) {
			return _cache.Get(trackId);
		}

		/// <summary>Returns a collection of tracks satisfying specified query.</summary>
		/// <param name="query">Query.</param>
		/// <returns>Collection of ITrack.</returns>
		public IEnumerable<ITrack> Search(string query) {
			var result = new List<ITrack>();
			foreach (var trackProvider in _providers) {
				var tracks = new List<ITrack>(trackProvider.OnSearch(query));
				_cache.Save(tracks);
				result.AddRange(tracks);
			}
			return result;
		}

		/// <summary>Adds specified provider to the collection.</summary>
		/// <param name="tracksProvider">Provider.</param>
		public void AddTracksProvider(IExtension tracksProvider) {
			_providers.Add(tracksProvider);
		}

		/// <summary>Occurs when track state changed.</summary>
		public event EventHandler<MusicLibraryEventArgs> TrackStateChanged;

		/// <summary>Collection of track providers.</summary>
		private readonly List<IExtension> _providers = new List<IExtension>();

		/// <summary>The cache.</summary>
		private readonly MusicLibraryCache _cache = new MusicLibraryCache();

		// TODO: Этот словарь наполняется очень быстро, после каждого поиска тут сотни треков с состоянии Download. (vkCom добавляет их сюда)
		/// <summary>The track states.</summary>
		private readonly Dictionary<ITrack, TrackState> _state = new Dictionary<ITrack, TrackState>();
	}
}
