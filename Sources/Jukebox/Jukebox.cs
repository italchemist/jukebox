
namespace Jukebox {
	using System.Collections.Generic;
	using Api;

	/// <summary>Jukebox.</summary>
	public sealed class Jukebox : IJukebox {
		/// <summary>Initializes a new instance of the <see cref="Jukebox"/> class.</summary>
		public Jukebox() {
			Properties = new Properties();
			Playlist = new Playlist();
			MusicLibrary = new MusicLibrary();
			Extensions = new List<IExtension>();

			Playlist.TrackEnqueued += OnTrackEnqueued;
		}

		/// <summary>Starts playing.</summary>
		public void Play() {
			if (_currentTrack != null)
				OnStateChanged(_currentTrack, JukeboxState.Play);
			else
				Next();
		}

		/// <summary>Pauses playing.</summary>
		public void Pause() {
			OnStateChanged(_currentTrack, JukeboxState.Pause);
		}

		/// <summary>Play next track.</summary>
		public void Next() {
			if (Playlist.Count >= 1) {
				// TODO: currentTrack can be null
				// TODO: send event "no more tracks"
				_currentTrack = Playlist.Dequeue();
				if (_currentTrack != null)
					OnStateChanged(_currentTrack, JukeboxState.Play);
			} else
				_currentTrack = null;
		}

		/// <summary>Gets properties.</summary>
		public IProperties Properties { get; private set; }

		/// <summary>Gets playlist.</summary>
		public IPlaylist Playlist { get; private set; }

		/// <summary>Gets music library.</summary>
		public IMusicLibrary MusicLibrary { get; private set; }

		/// <summary>Gets list of extensions.</summary>
		public List<IExtension> Extensions { get; private set; }

		/// <summary>Called when track enqueued.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="PlaylistEventArgs"/> instance containing the event data.</param>
		void OnTrackEnqueued(object sender, PlaylistEventArgs args) {
			Extensions.ForEach(e => e.OnTrackEnqueued(args.Track));
		}

		/// <summary>Called when state changed.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		private void OnStateChanged(ITrack track, JukeboxState state) {
			Extensions.ForEach(t => t.OnStateChanged(track, state));
		}

		/// <summary>Gets current track.</summary>
		private ITrack _currentTrack;
	}
}
