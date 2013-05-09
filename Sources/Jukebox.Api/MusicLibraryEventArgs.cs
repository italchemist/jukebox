
namespace Jukebox.Api {
	using System;

	/// <summary>Playlist event args.</summary>
	public sealed class MusicLibraryEventArgs : EventArgs {
		/// <summary>Initializes a new instance of the <see cref="MusicLibraryEventArgs"/> class.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">State of the track.</param>
		public MusicLibraryEventArgs(ITrack track, TrackState state) {
			Track = track;
			State = state;
		}

		/// <summary>Gets track.</summary>
		public ITrack Track { get; private set; }

		/// <summary>Gets the state.</summary>
		public TrackState State { get; private set; }
	}
}