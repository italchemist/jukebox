
namespace Jukebox.Api.Configuration {
	using System.Xml.Serialization;

	/// <summary>Configuration valiable.</summary>
	public class ConfigVariable {
		/// <summary>Gets or sets name of the variable.</summary>
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		/// <summary>Gets or sets value of the variable.</summary>
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
	}
}
