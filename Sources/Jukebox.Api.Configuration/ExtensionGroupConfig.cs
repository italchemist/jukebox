
namespace Jukebox.Api.Configuration {
	using System.Collections.ObjectModel;
	using System.Xml.Serialization;

	/// <summary>Configuration model.</summary>
	public sealed class ExtensionGroupConfig {
		/// <summary>Gets or sets name.</summary>
		[XmlElement("name")]
		public string Name { get; set; }

		/// <summary>Gets or sets require.</summary>
		[XmlElement("require")]
		public string Require { get; set; }

		/// <summary>Gets or sets collection of extensions.</summary>
		[XmlArray("extensions")]
		[XmlArrayItem("extension")]
		public Collection<ExtensionConfig> Extensions { get; private set; }
	}
}
