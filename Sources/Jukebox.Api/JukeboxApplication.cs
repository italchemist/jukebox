
namespace Jukebox.Api {
	using System;

	/// <summary>Application management interface.</summary>
	public static class JukeboxApplication {
		/// <summary>Initializes the <see cref="JukeboxApplication"/> class.</summary>
		static JukeboxApplication() {
			Configuration = new Configuration();
		}

		/// <summary>Reloads the application.</summary>
		public static void Reload() {
			var evnt = ReloadRequested;
			if (evnt != null) evnt(null, null);
		}

		/// <summary>Gets or sets configuration interface.</summary>
		public static Configuration Configuration { get; private set; }

		/// <summary>Occurs when user requests the application reload.</summary>
		public static event EventHandler<EventArgs> ReloadRequested;
	}
}
