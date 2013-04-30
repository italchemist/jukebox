
namespace Jukebox.Api {
	using System;

	/// <summary>Properties event args.</summary>
	public sealed class PropertiesEventArgs : EventArgs {
		/// <summary>Initializes a new instance of the <see cref="PropertiesEventArgs"/> class.</summary>
		/// <param name="name">The property name.</param>
		/// <param name="value">The value.</param>
		public PropertiesEventArgs(string name, string value) {
			Name = name;
			Value = value;
		}

		/// <summary>Gets property name.</summary>
		public string Name { get; private set; }

		/// <summary>Gets value.</summary>
		public string Value { get; private set; }
	}
}
