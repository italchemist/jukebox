
namespace Jukebox.Extensions.Misc.StartupLogo {
	using System;
	using System.Windows.Forms;

	public partial class StartupLogoWindow : Form {
		delegate void SetLoadingTextCallback(string text);

		public StartupLogoWindow() {
			InitializeComponent();
		}

		public void SetLoadingText(string text) {
			if (this.loadingText.InvokeRequired) {
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

		private void OnCloseWindowTimerTick(object sender, EventArgs e) {
			Close();
		}

		private void OnLogoPictureBoxClick(object sender, EventArgs e) {
			Close();
		}
	}
}
