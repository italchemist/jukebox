
namespace Jukebox {
	using System;
	using Api;

	/// <summary>Music track interface.</summary>
	public sealed class Track : ITrack {
		/// <summary>Initializes a new instance of the <see cref="Track"/> class.</summary>
		public Track() {
		}

		/// <summary>Initializes a new instance of the <see cref="Track"/> class.</summary>
		/// <param name="performer">The performer.</param>
		/// <param name="title">The title.</param>
		public Track(string performer, string title) {
			Performer = performer;
			Title = title;
		}

		/// <summary>Initializes a new instance of the <see cref="Track"/> class.</summary>
		/// <param name="performer">The performer.</param>
		/// <param name="title">The title.</param>
		/// <param name="state">State of the track.</param>
		public Track(string performer, string title, TrackState state) {
			Performer = performer;
			Title = title;
			State = state;
		}

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
