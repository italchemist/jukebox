
namespace Jukebox.Extensions.Misc.Console {
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using Api;

	/// <summary>Startup logo extwnsion.</summary>
	public sealed class ConsoleExtension : Extension, IDisposable {
		/// <summary>Finalizes an instance of the <see cref="ConsoleExtension"/> class.</summary>
		~ConsoleExtension() {
			Dispose();
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose() {
			_window.Dispose();
			GC.SuppressFinalize(this);
		}

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
			_window = new ConsoleWindow();
			_window.ShowDialog();
		}

		/// <summary>The startup logo window.</summary>
		private ConsoleWindow _window;
	}
}
