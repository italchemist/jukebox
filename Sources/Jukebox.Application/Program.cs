
namespace Jukebox.Application {
	using Configuration;

	/// <summary>Application entry point class.</summary>
	class Program {
		/// <summary>Application entry point.</summary>
		static void Main() {
			var config = ConfigLoader.Load(ConfigPath);
			new JukeboxApplicationHost().Run(config);
		}

		/// <summary>Config path.</summary>
		private const string ConfigPath = "config.xml";
	}
}
