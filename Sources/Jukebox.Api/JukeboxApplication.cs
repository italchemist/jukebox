
namespace Jukebox.Api {
	using System;

	/// <summary>Application management interface.</summary>
	public static class JukeboxApplication {
		/// <summary>Initializes the <see cref="JukeboxApplication"/> class.</summary>
		static JukeboxApplication() {
			Configuration = new JukeboxConfiguration();
			Log = new JukeboxLog();
		}

		/// <summary>Reloads the application.</summary>
		public static void Reload() {
			var evnt = ReloadRequested;
			if (evnt != null) evnt(null, null);
		}

		/// <summary>Gets configuration interface.</summary>
		public static JukeboxConfiguration Configuration { get; private set; }

		/// <summary>Gets the log.</summary>
		public static JukeboxLog Log { get; private set; }

		/// <summary>Occurs when user requests the application reload.</summary>
		public static event EventHandler<EventArgs> ReloadRequested;
	}
}
