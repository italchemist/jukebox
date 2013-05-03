
namespace Jukebox.Api.OAuth {
	using System;
	using System.Windows.Forms;

	/// <summary>OAuth aunthenication interface.</summary>
	public sealed class OAuthAuthentication {
		/// <summary>Initializes a new instance of the <see cref="OAuthAuthentication"/> class.</summary>
		/// <param name="uri">The URI.</param>
		public OAuthAuthentication(Uri uri) {
			_uri = uri;
		}

		/// <summary>Starts authenicatication process.</summary>
		public void Authenicate() {
			var form = new AuthenticationForm(_uri);
			form.WebBrowser.Navigated += WebBrowserOnNavigated;
			form.ShowDialog();
		}

		/// <summary>Webs the browser on navigated.</summary>
		/// <param name="sender">The sender.</param>
		/// <param name="webBrowserNavigatedEventArgs">The <see cref="WebBrowserNavigatedEventArgs"/> instance containing the event data.</param>
		private void WebBrowserOnNavigated(object sender, WebBrowserNavigatedEventArgs webBrowserNavigatedEventArgs) {
			var uri = webBrowserNavigatedEventArgs.Url;
			var evnt = Navigated;
			if (evnt != null) evnt(this, new OAuthEventArgs(uri));
		}

		/// <summary>Occurs when navigated to another page.</summary>
		public event EventHandler<OAuthEventArgs> Navigated;

		/// <summary>The uri.</summary>
		private readonly Uri _uri;
	}
}
