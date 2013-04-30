
namespace Jukebox.Tests {
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Collections.Generic;
	using Api;

	/// <summary>
	///This is a test class for PlaylistTest and is intended
	///to contain all PlaylistTest Unit Tests
	///</summary>
	[TestClass]
	public class PlaylistTest {
		[TestMethod] public void PlaylistConstructorWithTracksTest() {
			var track = new Track("Beatles", "Let It Be", TrackState.Ready);
			var target = new Playlist(new List<ITrack> { track });
			Assert.AreEqual(1, target.Count);
			var actual = target.Dequeue();
			Assert.AreEqual(track, actual);
		}

		/// <summary>Enqueue should increase count of tracks by one.</summary>
		[TestMethod] public void EnqueueShouldIncreaseCountOfTracksByOneTest() {
			var target = new Playlist();
			var track = new Track("Beatles", "Let It Be");
			target.Enqueue(track);
			Assert.AreEqual(1, target.Count);
		}

		/// <summary>Dequeue should decrease count of tracks by one.</summary>
		[TestMethod] public void DequeueShouldDecreaseCountOfTracksByOneTest() {
			var target = new Playlist();
			var track = new Track("Beatles", "Let It Be", TrackState.Ready);
			target.Enqueue(track);
			target.Dequeue();
			Assert.AreEqual(0, target.Count);
		}

		/// <summary>Dequeue should return track previously enqueued.</summary>
		[TestMethod] public void DequeueShouldReturnTrackPreviousleEnqueuedTest() {
			var target = new Playlist();
			var actual = new Track("Beatles", "Let It Be", TrackState.Ready);
			target.Enqueue(actual);
			var expected = target.Dequeue();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>Dequeue should return first track in ready state.</summary>
		[TestMethod] public void DequeueShouldReturnFirstTrackInReadyStateTest() {
			var target = new Playlist();
			var actual = new Track("Beatles", "Let It Be", TrackState.Ready);
			target.Enqueue(new Track("Beatles", "Abbey Road", TrackState.Downloading));
			target.Enqueue(actual);
			var expected = target.Dequeue();
			Assert.AreEqual(expected, actual);
		}

		/// <summary>Dequeue should return null if no track in ready state found.</summary>
		[TestMethod] public void DequeueShouldReturnNullIfNoTrackInReadyStateFoundTest() {
			var target = new Playlist(new List<ITrack> { new Track("Beatles", "Let It Be", TrackState.Downloading) });
			var actual = target.Dequeue();
			Assert.AreEqual(null, actual);
		}

		/// <summary>TrackEnqueued should raise when trac enqueued.</summary>
		[TestMethod] public void TrackEnqueuedShouldRaiseWhenTrackEnqueued() {
			var raised = false;
			var track = new Track("Beatles", "Let It Be", TrackState.Ready);
			var target = new Playlist();
			target.TrackEnqueued += (sender, args) => {
				raised = true;
				Assert.AreEqual(track, args.Track);
			};
			target.Enqueue(track);
			Assert.IsTrue(raised);
		}
	}
}
