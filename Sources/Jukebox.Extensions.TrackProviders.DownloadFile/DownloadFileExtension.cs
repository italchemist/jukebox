
namespace Jukebox.Extensions.TrackProviders.DownloadFile {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Net;
	using Api;
	using TagLib.Mpeg;

	/// <summary>Download extension.</summary>
	public class DownloadFileExtension : Extension {
		/// <summary>Calls on extesion initialization.</summary>
		/// <param name="jukebox">Jikebox.</param>
		/// <param name="vars">Variables.</param>
		public override void OnInitialize(IJukebox jukebox, IDictionary<string, string> vars) {
			_jukebox = jukebox;
			_downloadPath = vars.ContainsKey("path") && !string.IsNullOrEmpty(vars["path"]) ? vars["path"] : Path.GetTempPath();
			_invalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

			_log.WriteFormat("Tracks will be downloaded to {0}", _downloadPath);
		}

		/// <summary>Called when track enqueued.</summary>
		/// <param name="track">The track.</param>
		public override void OnTrackEnqueued(ITrack track) {
			if (_jukebox.MusicLibrary.GetTrackState(track) != TrackState.Download) return;

			var client = new WebClient();
			var path = GetPath(track);
			client.DownloadProgressChanged += OnDownloadProgressChanged;
			client.DownloadFileCompleted += OnDownloadCompleted;
			client.DownloadFileAsync(track.Uri, path, track);
		}

		/// <summary>Download completed.</summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">Event args.</param>
		private void OnDownloadCompleted(object sender, AsyncCompletedEventArgs e) {
			var track = (ITrack)e.UserState;
			if (e.Error == null) {
				track.Uri = new Uri(GetPath(track));
				SaveTags(track);
				_jukebox.MusicLibrary.SetTrackState(track, TrackState.Ready);
			} else {
				_jukebox.MusicLibrary.SetTrackState(track, TrackState.Error);
			}
		}

		/// <summary>Download progress changed.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
			var track = (ITrack)e.UserState;
			if (_jukebox.MusicLibrary.GetTrackState(track) != TrackState.Downloading) {
				_jukebox.MusicLibrary.SetTrackState(track, TrackState.Downloading);
			}
		}

		/// <summary>Gets path for the specified track.</summary>
		/// <param name="track">Track to get path for.</param>
		/// <returns>Path.</returns>
		private string GetPath(ITrack track) {
			var fileName = GetFileName(track);
			fileName = _invalidChars.Aggregate(fileName, (current, c) => current.Replace(c.ToString(CultureInfo.InvariantCulture), String.Empty));
			return Path.Combine(_downloadPath, fileName);
		}

		/// <summary>Gets file name for the specified track.</summary>
		/// <param name="track">Track to get file name to.</param>
		/// <returns>File name.</returns>
		private static string GetFileName(ITrack track) {
			string fileName;
			if (track.Performer != null && track.Title != null) {
				fileName = String.Format(CultureInfo.InvariantCulture, FileNamePattern, track.Performer, track.Title);
			} else {
				fileName = String.Format(CultureInfo.InvariantCulture, FileNameGuidPattern, Guid.NewGuid());
			}
			return fileName;
		}

		/// <summary>Saves tags to the mp3 file based on the track's information.</summary>
		/// <param name="track"></param>
		private static void SaveTags(ITrack track) {
			var file = new AudioFile(track.Uri.LocalPath);
			file.Tag.Performers = new[] { track.Performer };
			file.Tag.Title = track.Title;
			file.Save();
		}


		/// <summary>The jukebox.</summary>
		private IJukebox _jukebox;

		/// <summary>The log.</summary>
		private readonly IJukeboxLog _log = new JukeboxLog("download");

		/// <summary>Invalid path characters.</summary>
		private string _invalidChars;

		/// <summary>Path to download tracks to.</summary>
		private string _downloadPath;

		/// <summary>File name pattern.</summary>
		private const string FileNamePattern = "{0} - {1}.mp3";

		/// <summary>File name guid pattern.</summary>
		private const string FileNameGuidPattern = "{0}.mp3";
	}
}
