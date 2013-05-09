
namespace Jukebox.Api {
	using System;

	/// <summary>Music track interface.</summary>
	public interface ITrack {
		/// <summary>Gets or sets title.</summary>
		string Title { get; set; }

		/// <summary>Gets or sets performer.</summary>
		string Performer { get; set; }

		/// <summary>Gets or sets duration.</summary>
		TimeSpan Duration { get; set; }

		/// <summary>Gets or sets Uri track is located.</summary>
		Uri Uri { get; set; }
	}
}
