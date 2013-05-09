
namespace Jukebox.Extensions.Misc.Autoplay {
	using Api;

	/// <summary>Autoplay extension.</summary>
	public class AutoplayExtension : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, System.Collections.Generic.IDictionary<string, string> vars) {
			_jukebox = jukebox;
		}

		/// <summary>Called when track state changed.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		public override void OnTrackStateChanged(ITrack track, TrackState state) {
			if (state != TrackState.Ready) return;
			if (_jukebox.State != JukeboxState.Stop) return;

			_log.Write("Start playing.");
			_jukebox.Play();
		}

		/// <summary>The jukebox.</summary>
		private IJukebox _jukebox;

		/// <summary>The log.</summary>
		private readonly IJukeboxLog _log = new JukeboxLog("autoplay");
	}
}
