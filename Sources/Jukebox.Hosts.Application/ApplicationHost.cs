
namespace Jukebox.Hosts.Application {
	using System;
	using Api;
	using Api.Configuration;

	/// <summary>Jukebox application host.</summary>
	class ApplicationHost {
		/// <summary>Runs application.</summary>
		/// <param name="config">Configuration.</param>
		public void Run(Config config) {
			_config = config;

			JukeboxApplication.Configuration.VariableChanged += OnConfigurationVariableChanged;
			JukeboxApplication.ReloadRequested += OnApplicationReloadRequested;	

			try {
				_extensionsLibrary.LoadExtensions(_jukebox, config);
			} catch (Exception ex) {
				foreach (var x in _jukebox.Extensions) {
					x.OnError(ex);
				}
			}
		}

		/// <summary>Called when application reload requested.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		void OnApplicationReloadRequested(object sender, EventArgs e) {
			_extensionsLibrary.LoadExtensions(_jukebox, _config);
		}

		/// <summary>Called when configuration variable changed.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="ConfiguratonEventArgs"/> instance containing the event data.</param>
		void OnConfigurationVariableChanged(object sender, ConfiguratonEventArgs e) {
			_config.SetVariable(e.ExtensionName, e.Variable, e.Value);
			ConfigLoader.Save(_config);
		}

		/// <summary>The config.</summary>
		private Config _config;

		/// <summary>The jukebox.</summary>
		private readonly Jukebox _jukebox = new Jukebox();

		/// <summary>The extensions library.</summary>
		private readonly ExtensionsLibrary _extensionsLibrary = new ExtensionsLibrary();
	}
}
