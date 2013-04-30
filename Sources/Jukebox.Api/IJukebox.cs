
namespace Jukebox.Api {
	using System.Collections.Generic;

	/// <summary>Player interface.</summary>
	public interface IJukebox {
		/// <summary>Starts playing.</summary>
		void Play();

		/// <summary>Pauses playing.</summary>
		void Pause();

		/// <summary>Starts playing next track.</summary>
		void NextTrack();

		/// <summary>Gets properties.</summary>
		IProperties Properties { get; }

		/// <summary>Gets playlist.</summary>
		IPlaylist Playlist { get; }
		
		/// <summary>Gets music library.</summary>
		IMusicLibrary MusicLibrary { get; }

		/// <summary>Gets list of extensions.</summary>
		ICollection<IExtension> Extensions { get; }

		/// <summary>Gets state.</summary>
		JukeboxState State { get; }
	}
}
