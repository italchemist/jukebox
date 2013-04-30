
namespace Jukebox.Api {
	using System;

	/// <summary>Properties collection interface.</summary>
	public interface IProperties {
		/// <summary>Sets the value for the specified property.</summary>
		/// <param name="name">Name of the property.</param>
		/// <param name="value">Value of the property.</param>
		void Set(string name, string value);

		/// <summary>Gets the value of the property.</summary>
		/// <param name="name">Name of the property.</param>
		/// <returns>Value.</returns>
		string Get(string name);

		/// <summary>Occurs when property changed.</summary>
		event EventHandler<PropertiesEventArgs> PropertyChanged;
	}
}
