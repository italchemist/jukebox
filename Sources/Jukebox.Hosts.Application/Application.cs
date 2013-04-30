
namespace Jukebox.Hosts.Application {
	using Api.Configuration;

	/// <summary>Application entry point class.</summary>
	class Application {
		/// <summary>Application entry point.</summary>
		static void Main() {
			var config = ConfigLoader.Load(ConfigPath);
			new ApplicationHost().Run(config);
		}

		/// <summary>Config path.</summary>
		private const string ConfigPath = "config.xml";
	}
}
