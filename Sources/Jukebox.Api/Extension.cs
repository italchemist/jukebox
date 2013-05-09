
namespace Jukebox.Api {
	using System;
	using System.Collections.Generic;

	/// <summary>Basic extension interface.</summary>
	public abstract class Extension : IExtension {
		/// <summary>Called when extension loaded.</summary>
		/// <param name="jukebox">The jukebox.</param>
		/// <param name="vars">The variables.</param>
		public virtual void OnInitialize(IJukebox jukebox, IDictionary<string, string> vars) { }

		// Jukebox Methods

		/// <summary>Called when property changed.</summary>
		/// <param name="name">The name of the name.</param>
		/// <param name="value">The value.</param>
		public virtual void OnPropertyChanged(string name, string value) { }

		/// <summary>Called when playing state of the jukebox changed.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		public virtual void OnStateChanged(ITrack track, JukeboxState state) { }

		/// <summary>Called when track enqueued.</summary>
		/// <param name="track">The track.</param>
		public virtual void OnTrackEnqueued(ITrack track) { }

		/// <summary>Called when track state changed.</summary>
		/// <param name="track">The track.</param>
		/// <param name="state">The state.</param>
		public virtual void OnTrackStateChanged(ITrack track, TrackState state) { }


		// Data Provider Methods

		/// <summary>Called when search requested.</summary>
		/// <param name="query">The query.</param>
		/// <returns>List of the tracks.</returns>
		public virtual IEnumerable<ITrack> OnSearch(string query) {
			return new List<ITrack>();
		}


		// Infrastructure Methods

		/// <summary>Called when another extension loaded.</summary>
		/// <param name="extension">The extension.</param>
		public virtual void OnExtensionLoaded(IExtension extension) { }

		/// <summary>Called when error occured.</summary>
		/// <param name="exception">The exception.</param>
		public virtual void OnError(Exception exception) { }
	}
}
