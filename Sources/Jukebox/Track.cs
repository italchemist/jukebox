
namespace Jukebox {
	using System;
	using Api;

	/// <summary>Music track interface.</summary>
	public sealed class Track : ITrack {
		/// <summary>Gets or sets title.</summary>
		public string Title { get; set; }

		/// <summary>Gets or sets performer.</summary>
		public string Performer { get; set; }

		/// <summary>Gets or sets duration.</summary>
		public TimeSpan Duration { get; set; }

		/// <summary>Gets or sets track state.</summary>
		public TrackState State { get; set; }

		/// <summary>Gets or sets Uri track is located.</summary>
		public Uri Uri { get; set; }
	}
}
