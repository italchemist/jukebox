
namespace Jukebox.Extensions.Interfaces.TrayControlCenter {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Threading;
	using System.Windows.Forms;
	using Api;

	/// <summary>Tray control center extension.</summary>
	public class TrayControlCenterExtension : Extension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public override void OnInitialize(IJukebox jukebox, IDictionary<string, string> vars) {
			var t = new Thread(OnExtensionThreadStart);
			t.SetApartmentState(ApartmentState.STA);
			t.Start();
		}

		/// <summary>Called when extension thread started.</summary>
		private static void OnExtensionThreadStart() {
			Application.EnableVisualStyles();

			var resources = new ComponentResourceManager(typeof (MainForm));
			var notifyIcon = new NotifyIcon {
				Icon = (System.Drawing.Icon) (resources.GetObject("notifyIcon1.Icon")),
				Visible = true
			};
			notifyIcon.ShowBalloonTip(1000, "Jukebox", "Jukebox has been started", ToolTipIcon.Info);
			
			Application.Run();
		}

		/// <summary>Called when error occured.</summary>
		/// <param name="exception">The exception.</param>
		public override void OnError(Exception exception) {
			var error = new ErrorForm();
			error.Show();
		}
	}
}
