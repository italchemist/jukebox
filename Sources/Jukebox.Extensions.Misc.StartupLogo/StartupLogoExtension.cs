
namespace Jukebox.Extensions.Misc.StartupLogo {
	using System.Collections.Generic;
	using System.Threading;
	using Api;

	/// <summary>Startup logo extwnsion.</summary>
	class StartupLogoExtension : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, IDictionary<string, string> vars) {
			var t = new Thread(OnStartupLogoWindowShowThread);
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
			t.Join(1000);
		}

		/// <summary>Called when show logo start thread.</summary>
		private void OnStartupLogoWindowShowThread() {
			_window = new StartupLogoWindow();
			_window.ShowDialog();
		}

		/// <summary>Called when another extension loaded.</summary>
		/// <param name="extension">The extension.</param>
		public override void OnExtensionLoaded(IExtension extension) {
			if (_window == null) return;
			_window.SetLoadingText(extension.GetType().Name);
		}

		/// <summary>The startup logo window.</summary>
		private StartupLogoWindow _window;
	}
}
