
namespace Jukebox.Extensions.Transmitters.Streaming {
	using System;
	using Api;

	/// <summary>Streaing transmitter extension.</summary>
	public class StreaingTransitterExtension : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, System.Collections.Generic.IDictionary<string, string> vars) {
			var uri = vars.ContainsKey("uri") ? vars["uri"] : "http://localhost:8000";
			_host = new StreamingServiceHost(new Uri(uri));
			_host.Run();
		}

		/// <summary>Streaming service host.</summary>
		private StreamingServiceHost _host;
	}
}
