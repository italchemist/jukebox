
namespace Jukebox.Api.Configuration {
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Xml.Serialization;

	/// <summary>Configuration model.</summary>
	[XmlRoot(ElementName = "config")]
	public sealed class Config {
		/// <summary>Gets or sets path.</summary>
		public string Path { get; set; }

		/// <summary>Gets or sets collection of extensions.</summary>
		[XmlArray("extensionGroups")]
		[XmlArrayItem("extensionsGroup")]
		public Collection<ExtensionGroupConfig> ExtensionGroups { get; private set; }

		public ExtensionConfig FindExtension(string name) {
			return ExtensionGroups
				.SelectMany(group => group.Extensions)
				.FirstOrDefault(ext => ext.Name == name);
		}

		public void SetVariable(string extensionName, string variableName, string variableValue){
			var c = FindExtension(extensionName);
			if (c == null) return;

			var var = c.Vars.FirstOrDefault(v => v.Name == variableName);
			if (var == null) {
				var = new ConfigVariable { Name = variableName, Value = variableValue };
				c.Vars.Add(var);
			} else {
				var.Value = variableValue;
			}
		}
	}
}
