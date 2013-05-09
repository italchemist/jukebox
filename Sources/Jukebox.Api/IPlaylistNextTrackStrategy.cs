
namespace Jukebox.Api {
	using System.Collections.Generic;

	/// <summary></summary>
	public interface IPlaylistNextTrackStrategy {
		/// <summary>Gets next track.</summary>
		/// <param name="tracks">The tracks.</param>
		/// <returns>Track.</returns>
		ITrack GetNext(IEnumerable<ITrack> tracks);
	}
}