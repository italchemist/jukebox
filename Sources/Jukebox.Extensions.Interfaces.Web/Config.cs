
namespace Jukebox.Extensions.Interfaces.Web {
	using Api;

	/// <summary>Extension configuration.</summary>
	static class Config {
		/// <summary>Gets or sets the title.</summary>
		public static string Title { get; set; }
		
		/// <summary>Gets or sets the message.</summary>
		public static string Message { get; set; }

		/// <summary>Gets or sets the stream path.</summary>
		public static string StreamPath { get; set; }

		/// <summary>Gets or sets the jukebox.</summary>
		public static IJukebox Jukebox { get; set; }
	}
}
