
namespace Jukebox.Extensions.Transmitters.Local {
	using System.IO;
	using Api;
	using NAudio.Wave;
	using System.Threading;

	/// <summary>Local transmitter extension.</summary>
	public class LocalTransmitterExtension : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, System.Collections.Generic.IDictionary<string, string> vars) {
			_jukebox = jukebox;
		}

		/// <summary>Called when playing state of the jukebox changed.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		public override void OnStateChanged(ITrack track, JukeboxState state) {
			if (state != JukeboxState.Play) return;
			
			new Thread(x => {
				using (var ms = File.OpenRead(track.Uri.LocalPath))
				using (var rdr = new Mp3FileReader(ms))
				using (var wavStream = WaveFormatConversionStream.CreatePcmStream(rdr))
				using (var baStream = new BlockAlignReductionStream(wavStream))
				using (var waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback())) {
					waveOut.Init(baStream);
					waveOut.Play();
					while (baStream.Position < baStream.Length) {
						Thread.Sleep(1000);
					}
					_jukebox.NextTrack();
				}
			}).Start();
		}

		/// <summary>The jukebox</summary>
		private IJukebox _jukebox;
	}
}
