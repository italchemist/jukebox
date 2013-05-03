
namespace Jukebox.Api.OAuth {
	using System;
	using System.Windows.Forms;

	/// <summary>Authentication form.</summary>
	public partial class AuthenticationForm : Form {
		/// <summary>Initializes a new instance of the <see cref="AuthenticationForm"/> class.</summary>
		public AuthenticationForm(Uri uri) {
			_uri = uri;
			InitializeComponent();
			WebBrowser.ScriptErrorsSuppressed = true;
		}

		/// <summary>Handles the Load event of the AuthenticationForm control.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnAuthenticationFormLoad(object sender, EventArgs e) {
			WebBrowser.Navigate(_uri);
		}

		/// <summary>The access token.</summary>
		public string AccessToken { get; set; }

		/// <summary>The uri.</summary>
		private readonly Uri _uri;
	}
}
