
namespace Jukebox.Api {
	using System;

	/// <summary>Playlist interface.</summary>
	public interface IPlaylist {
		/// <summary>Enqueues specified track.</summary>
		/// <param name="track">Track.</param>
		void Enqueue(ITrack track);

		/// <summary>Dequeues track.</summary>
		/// <returns>Track.</returns>
		ITrack Dequeue();

		/// <summary>Occurs when track enqueued.</summary>
		event EventHandler<PlaylistEventArgs> TrackEnqueued;

		/// <summary>Occurs when track dequeued.</summary>
		event EventHandler<PlaylistEventArgs> TrackDequeued;

		/// <summary>Gets number of tracks.</summary>
		int Count { get; }
	}
}
