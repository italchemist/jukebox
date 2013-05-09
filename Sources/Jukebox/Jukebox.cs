
namespace Jukebox {
	using System.Collections.Generic;
	using Api;

	/// <summary>Jukebox.</summary>
	public sealed class Jukebox : IJukebox {
		/// <summary>Initializes a new instance of the <see cref="Jukebox"/> class.</summary>
		public Jukebox() {
			Properties = new Properties();
			MusicLibrary = new MusicLibrary();
			Playlist = new Playlist { NextTrackStrategy = new NextReadyTrackStrategy(MusicLibrary) };
			Extensions = new List<IExtension>();

			Playlist.TrackEnqueued += OnTrackEnqueued;
			MusicLibrary.TrackStateChanged += OnTrackStateChanged;
		}

		/// <summary>Starts playing.</summary>
		public void Play() {
			if (_currentTrack != null)
				OnStateChanged(_currentTrack, JukeboxState.Play);
			else
				NextTrack();
		}

		/// <summary>Pauses playing.</summary>
		public void Pause() {
			OnStateChanged(_currentTrack, JukeboxState.Pause);
		}

		/// <summary>Play next track.</summary>
		public void NextTrack() {
			if (Playlist.Count >= 1) {
				// TODO: currentTrack can be null
				// TODO: send event "no more tracks"
				_currentTrack = Playlist.Dequeue();
				if (_currentTrack != null)
					OnStateChanged(_currentTrack, JukeboxState.Play);
			} else {
				_currentTrack = null;
				OnStateChanged(null, JukeboxState.Stop);
			}
		}

		/// <summary>Gets state.</summary>
		public JukeboxState State { get; private set; }

		/// <summary>Gets properties.</summary>
		public IProperties Properties { get; private set; }

		/// <summary>Gets playlist.</summary>
		public IPlaylist Playlist { get; private set; }

		/// <summary>Gets music library.</summary>
		public IMusicLibrary MusicLibrary { get; private set; }

		/// <summary>Gets list of extensions.</summary>
		public ICollection<IExtension> Extensions { get; private set; }

		/// <summary>Called when track enqueued.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="PlaylistEventArgs"/> instance containing the event data.</param>
		private void OnTrackEnqueued(object sender, PlaylistEventArgs args) {
			_log.WriteFormat("Track {0} enueued", args.Track);
			foreach (var extension in Extensions) {
				extension.OnTrackEnqueued(args.Track);
			}
		}

		/// <summary>Called when track state changed.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="MusicLibraryEventArgs"/> instance containing the event data.</param>
		private void OnTrackStateChanged(object sender, MusicLibraryEventArgs args) {
			//_log.WriteFormat("State of {0} changed to {1}", args.Track, args.State);
			foreach (var extension in Extensions) {
				extension.OnTrackStateChanged(args.Track, args.State);
			}
		}

		/// <summary>Called when state changed.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		private void OnStateChanged(ITrack track, JukeboxState state) {
			_log.WriteFormat("State of player changed to {0}", state);
			foreach (var extension in Extensions) {
				extension.OnStateChanged(track, state);
			}
			State = state;
		}

		/// <summary>Gets current track.</summary>
		private ITrack _currentTrack;

		/// <summary>The log.</summary>
		private readonly IJukeboxLog _log = new JukeboxLog("core");
	}
}
