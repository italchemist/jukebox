
namespace Jukebox.Api.Configuration {
	using System.IO;
	using System.Xml.Serialization;

	/// <summary>Config loader.</summary>
	public static class ConfigLoader {
		/// <summary>Loads configuration from file by specified path.</summary>
		/// <param name="path">Path to file to load configuration from.</param>
		/// <returns>Config.</returns>
		public static Config Load(string path) {
			using (var file = File.OpenRead(path)) {
				var serializer = new XmlSerializer(typeof(Config));
				var config = (Config)serializer.Deserialize(file);
				config.Path = path;
				return config;
			}
		}

		/// <summary>Saves configuration to file.</summary>
		/// <param name="config">Config to save.</param>
		public static void Save(Config config) {
			File.Delete(config.Path);
			using (var file = File.OpenWrite(config.Path)) {
				var serializer = new XmlSerializer(typeof(Config));
				serializer.Serialize(file, config);
			}
		}
	}
}
