
namespace Jukebox {
	using System.Collections.Generic;
	using System.Linq;
	using Api;

	/// <summary>Next ready track.</summary>
	class NextReadyTrackStrategy : IPlaylistNextTrackStrategy {
		/// <summary>Initializes a new instance of the <see cref="NextReadyTrackStrategy"/> class.</summary>
		/// <param name="musicLibrary">The music library.</param>
		public NextReadyTrackStrategy(IMusicLibrary musicLibrary) {
			_musicLibrary = musicLibrary;
		}

		/// <summary>Gets next track.</summary>
		/// <param name="tracks">The tracks.</param>
		/// <returns>Track.</returns>
		public ITrack GetNext(IEnumerable<ITrack> tracks) {
			return tracks.FirstOrDefault(track => _musicLibrary.GetTrackState(track) == TrackState.Ready);
		}

		/// <summary>The music library.</summary>
		private readonly IMusicLibrary _musicLibrary;
	}
}
