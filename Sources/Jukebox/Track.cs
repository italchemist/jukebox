
namespace Jukebox {
	using System;
	using System.Globalization;
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

		/// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString() {
			return string.Format(CultureInfo.CurrentCulture, "{0} - {1} [{2}:{3}]", Performer, Title, Duration.Minutes, Duration.Seconds);
		}

		/// <summary>Gets or sets title.</summary>
		public string Title { get; set; }

		/// <summary>Gets or sets performer.</summary>
		public string Performer { get; set; }

		/// <summary>Gets or sets duration.</summary>
		public TimeSpan Duration { get; set; }

		/// <summary>Gets or sets Uri track is located.</summary>
		public Uri Uri { get; set; }
	}
}
