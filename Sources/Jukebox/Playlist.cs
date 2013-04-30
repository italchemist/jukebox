
namespace Jukebox {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Api;

	/// <summary>Playlist.</summary>
	public sealed class Playlist : IPlaylist {
		/// <summary>Initializes a new instance of the <see cref="Playlist"/> class.</summary>
		public Playlist() {
		}

		/// <summary>Initializes a new instance of the <see cref="Playlist"/> class.</summary>
		/// <param name="tracks">The tracks.</param>
		public Playlist(IEnumerable<ITrack> tracks) {
			_tracks.AddRange(tracks);
		}

		/// <summary>Enqueues specified track.</summary>
		/// <param name="track">Track.</param>
		public void Enqueue(ITrack track) {
			_tracks.Insert(_tracks.Count, track);
			OnTrackEnqueued(this, new PlaylistEventArgs(track));
		}

		/// <summary>Dequeues track.</summary>
		/// <returns>Track.</returns>
		public ITrack Dequeue() {
			var track = _tracks.FirstOrDefault(t => t.State == TrackState.Ready);
			_tracks.Remove(track);
			return track;
		}

		/// <summary>Occurs when track enqueued.</summary>
		public event EventHandler<PlaylistEventArgs> TrackEnqueued;

		/// <summary>Gets number of tracks.</summary>
		public int Count { get { return _tracks.Count; } }


		/// <summary>Called when track enqueued.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="PlaylistEventArgs"/> instance containing the event data.</param>
		private void OnTrackEnqueued(object sender, PlaylistEventArgs e) {
			var evnt = TrackEnqueued;
			if (evnt != null) evnt(sender, e);
		}

		/// <summary>Queue of tracks.</summary>
		private readonly List<ITrack> _tracks = new List<ITrack>();
	}
}
