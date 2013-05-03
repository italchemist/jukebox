
namespace Jukebox.Extensions.Misc.StartupLogo {
	using System;
	using System.Windows.Forms;

	/// <summary>Startup Logo window.</summary>
	public partial class StartupLogoWindow : Form {
		/// <summary>Initializes a new instance of the <see cref="StartupLogoWindow"/> class.</summary>
		public StartupLogoWindow() {
			InitializeComponent();
		}

		/// <summary>Sets the loading text.</summary>
		/// <param name="text">The text.</param>
		public void SetLoadingText(string text) {
			if (loadingText.InvokeRequired) {
				var d = new SetLoadingTextCallback(SetLoadingText);
				Invoke(d, new object[] { text });
			} else {
				loadingText.Text = text;
				closeWindowTimer.Stop();
				closeWindowTimer.Enabled = true;
				closeWindowTimer.Interval = 5000;
				closeWindowTimer.Start();
			}
		}

		/// <summary>Called when close window timer tick.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnCloseWindowTimerTick(object sender, EventArgs e) {
			Close();
		}

		/// <summary>Called when logo picture box clicked.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnLogoPictureBoxClick(object sender, EventArgs e) {
			Close();
		}

		/// <summary>Set loading text callback.</summary>
		/// <param name="text">The text.</param>
		delegate void SetLoadingTextCallback(string text);
	}
}
