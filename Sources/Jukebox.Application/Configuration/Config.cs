
namespace Jukebox.Application.Configuration {
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Xml.Serialization;

	/// <summary>Configuration model.</summary>
	[XmlRoot(ElementName = "config")]
	public class Config {
		/// <summary>Gets or sets collection of extensions.</summary>
		[XmlArray("extensionGroups")]
		[XmlArrayItem("extensionsGroup")]
		public Collection<ExtensionGroupConfig> ExtensionGroups { get; set; }

		public ExtensionConfig FindExtension(string name) {
			return ExtensionGroups
				.SelectMany(group => group.Extensions)
				.FirstOrDefault(ext => ext.Name == name);
		}
	}
}
