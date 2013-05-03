
namespace Jukebox.Api.OAuth {
	using System;

	/// <summary>OAuth event args.</summary>
	public class OAuthEventArgs : EventArgs {
		/// <summary>Initializes a new instance of the <see cref="OAuthEventArgs"/> class.</summary>
		/// <param name="uri">The URI.</param>
		public OAuthEventArgs(Uri uri) {
			Uri = uri;
		}
		
		/// <summary>Gets the URI.</summary>
		public Uri Uri { get; private set; }
	}
}