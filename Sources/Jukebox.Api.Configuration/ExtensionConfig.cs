
namespace Jukebox.Api.Configuration {
	using System.Collections.ObjectModel;
	using System.Xml.Serialization;

	/// <summary>Extension configuration.</summary>
	public sealed class ExtensionConfig {
		/// <summary>Gets or sets name.</summary>
		[XmlElement("name")]
		public string Name { get; set; }

		/// <summary>Gets or sets require.</summary>
		[XmlElement("require")]
		public string Require { get; set; }

		/// <summary>Gets or sets path to assembly.</summary>
		[XmlElement("path")]
		public string AssemblyPath { get; set; }

		/// <summary>Gets or sets variables.</summary>
		[XmlArray("vars")]
		[XmlArrayItem("var")]
		public Collection<ConfigVariable> Vars { get; set; }
	}
}
