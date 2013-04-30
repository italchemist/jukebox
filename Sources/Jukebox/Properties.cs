
namespace Jukebox {
	using System;
	using System.Collections.Generic;
	using Api;

	/// <summary>Properties collection.</summary>
	public sealed class Properties : IProperties {
		/// <summary>Sets the value for the specified property.</summary>
		/// <param name="name">Name of the property.</param>
		/// <param name="value">Value of the property.</param>
		public void Set(string name, string value) {
			_properties[name] = value;
			OnPropertyChanged(this, new PropertiesEventArgs(name, value));
		}

		/// <summary>Gets the value of the property.</summary>
		/// <param name="name">Name of the property.</param>
		/// <returns>Value.</returns>
		public string Get(string name) {
			string value;
			_properties.TryGetValue(name, out value);
			return value;
		}

		/// <summary>Occurs when property changed.</summary>
		public event EventHandler<PropertiesEventArgs> PropertyChanged;


		/// <summary>Called when property changed.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="PropertiesEventArgs"/> instance containing the event data.</param>
		private void OnPropertyChanged(object sender, PropertiesEventArgs e) {
			var evnt = PropertyChanged;
			if (evnt != null) evnt(sender, e);
		}

		/// <summary>Properties.</summary>
		private readonly Dictionary<string, string> _properties = new Dictionary<string,string>();
	}
}