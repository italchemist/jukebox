
namespace Jukebox.Api {
	using System;

	/// <summary>Configuration interface.</summary>
	public class Configuration {
		/// <summary>Sets the value of the variable for extension specified by name.</summary>
		/// <param name="extensionName">Extension name.</param>
		/// <param name="variable">Variable name.</param>
		/// <param name="value">Variable value.</param>
		public void Set(string extensionName, string variable, string value) {
			var evnt = VariableChanged;
			if (evnt != null) {
				evnt(null, new ConfiguratonEventArgs(extensionName, variable, value));
			}
		}

		/// <summary>Occurs when variable changed</summary>
		public event EventHandler<ConfiguratonEventArgs> VariableChanged;
	}
}
