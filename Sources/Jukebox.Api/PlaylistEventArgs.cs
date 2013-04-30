
namespace Jukebox.Api {
	using System;

	/// <summary>Playlist event args.</summary>
	public sealed class PlaylistEventArgs : EventArgs {
		/// <summary>Initializes a new instance of the <see cref="PlaylistEventArgs"/> class.</summary>
		/// <param name="track">The track.</param>
		public PlaylistEventArgs(ITrack track) {
			Track = track;
		}

		/// <summary>Gets track.</summary>
		public ITrack Track { get; private set; }
	}
}