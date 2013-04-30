
namespace Jukebox.Application.Configuration {
	using System.IO;
	using System.Xml.Serialization;

	/// <summary>Config loader.</summary>
	sealed class ConfigLoader {
		/// <summary>Loads configuration from file by specified path.</summary>
		/// <param name="path">Path to file to load configuration from.</param>
		/// <returns>Config.</returns>
		public static Config Load(string path) {
			using (var file = File.OpenRead(path)) {
				var serializer = new XmlSerializer(typeof(Config));
				var config = (Config)serializer.Deserialize(file);
				return config;
			}
		}

		/// <summary>Saves configuration to file.</summary>
		/// <param name="config">Config to save.</param>
		/// <param name="path">Path to file to save configuration to.</param>
		public static void Save(Config config, string path) {
			File.Delete(path);
			using (var file = File.OpenWrite(path)) {
				var serializer = new XmlSerializer(typeof(Config));
				serializer.Serialize(file, config);
			}
		}
	}
}
