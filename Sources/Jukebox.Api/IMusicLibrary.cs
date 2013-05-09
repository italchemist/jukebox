
using System;

namespace Jukebox.Api {
	using System.Collections.Generic;

	/// <summary>Music library interface.</summary>
	public interface IMusicLibrary {
		/// <summary>Gets cache id of the specified track.</summary>
		/// <param name="track">The track.</param>
		/// <returns>Cache Id.</returns>
		string GetCacheId(ITrack track);

		/// <summary>Gets the track by specified track id.</summary>
		/// <param name="trackId">The track id.</param>
		/// <returns>Track. Null if nothing found.</returns>
		ITrack GetTrackFromCache(string trackId);

		/// <summary>Returns a collection of tracks satisfying specified query.</summary>
		/// <param name="query">Query.</param>
		/// <returns>Collection of ITrack.</returns>
		IEnumerable<ITrack> Search(string query);

		/// <summary>Adds specified provider to the collection.</summary>
		/// <param name="tracksProvider">Provider.</param>
		void AddTracksProvider(IExtension tracksProvider);

		/// <summary>Ges the state of the track.</summary>
		/// <param name="track">The track.</param>
		/// <returns>State of the track.</returns>
		TrackState GeTrackState(ITrack track);

		/// <summary>Sets the state of the track.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		void SetTrackState(ITrack track, TrackState state);

		/// <summary>Occurs when track state changed.</summary>
		event EventHandler<MusicLibraryEventArgs> TrackStateChanged;
	}
}
