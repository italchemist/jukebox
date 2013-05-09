
namespace Jukebox.Api.OAuth {
	using System;
	using System.Windows.Forms;

	/// <summary>Authentication form.</summary>
	sealed partial class AuthenticationForm : Form {
		/// <summary>Initializes a new instance of the <see cref="AuthenticationForm"/> class.</summary>
		public AuthenticationForm(Uri uri) {
			_uri = uri;
			InitializeComponent();
			webBrowser.ScriptErrorsSuppressed = true;
		}

		/// <summary>Handles the Load event of the AuthenticationForm control.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnAuthenticationFormLoad(object sender, EventArgs e) {
			webBrowser.Navigate(_uri);
		}

		/// <summary>Gets the web browser.</summary>
		public WebBrowser WebBrowser {
			get { return webBrowser; }
		}

		/// <summary>The uri.</summary>
		private readonly Uri _uri;
	}
}
