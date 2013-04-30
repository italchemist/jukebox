
namespace Jukebox.Api {
	using System;

	/// <summary>Configuration event args.</summary>
	public class ConfiguratonEventArgs : EventArgs {
		/// <summary>Initializes a new instance of the <see cref="ConfiguratonEventArgs"/> class.</summary>
		/// <param name="extensionName">Name of the extension.</param>
		/// <param name="variable">The variable.</param>
		/// <param name="value">The value.</param>
		public ConfiguratonEventArgs(string extensionName, string variable, string value) {
			ExtensionName = extensionName;
			Variable = variable;
			Value = value;
		}

		/// <summary>Gets the name of the extension.</summary>
		public string ExtensionName { get; private set; }

		/// <summary>Gets the variable.</summary>
		public string Variable { get; private set; }

		/// <summary>Gets the value of the variable.</summary>
		public string Value { get; private set; }
	}
}
