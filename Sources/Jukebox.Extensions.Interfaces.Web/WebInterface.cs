
namespace Jukebox.Extensions.Interfaces.Web {
	using System;
	using System.Collections.Generic;
	using Api;
	using Nancy.Hosting.Self;

	/// <summary>Web interface extension.</summary>
	public sealed class WebInterfaceExtension : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, IDictionary<string, string> vars) {
			if (!vars.ContainsKey("streamPath")) return;
			if (!vars.ContainsKey("host")) return;

			Config.Title = vars["title"];
			Config.Message = vars["message"];
			Config.StreamPath = vars["streamPath"];
			Config.Jukebox = jukebox;

			var host = new NancyHost(new[] { new Uri(vars["host"]) });
			host.Start();
		}
	}
}
