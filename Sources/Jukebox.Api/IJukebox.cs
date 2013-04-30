
using System.Collections.Generic;

namespace Jukebox.Api {
	/// <summary>Player interface.</summary>
	public interface IJukebox {
		/// <summary>Starts playing.</summary>
		void Play();

		/// <summary>Pauses playing.</summary>
		void Pause();

		/// <summary>Starts playing next track.</summary>
		void Next();

		/// <summary>Gets properties.</summary>
		IProperties Properties { get; }

		/// <summary>Gets playlist.</summary>
		IPlaylist Playlist { get; }
		
		/// <summary>Gets music library.</summary>
		IMusicLibrary MusicLibrary { get; }

		/// <summary>Gets list of extensions.</summary>
		List<IExtension> Extensions { get; }
	}
}
