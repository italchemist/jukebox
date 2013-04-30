
namespace Jukebox.Api {
	/// <summary>Track state.</summary>
	public enum TrackState {
		/// <summary>Unknown state.</summary>
		Unknown,

		/// <summary>Download state.</summary>
		Download,

		/// <summary>Downloading state.</summary>
		Downloading,

		/// <summary>Ready to play.</summary>
		Ready,

		/// <summary>Error.</summary>
		Error
	}
}
