
namespace Jukebox.Tests {
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Api;
	
	/// <summary>
	///This is a test class for JukeboxTest and is intended
	///to contain all JukeboxTest Unit Tests
	///</summary>
	[TestClass] public class JukeboxTest {
		/// <summary>A test for Jukebox Constructor</summary>
		[TestMethod] public void JukeboxConstructorTest() {
			var target = new Jukebox();
			Assert.IsNotNull(target.Extensions);
			Assert.IsNotNull(target.MusicLibrary);
			Assert.IsNotNull(target.Playlist);
			Assert.IsNotNull(target.Properties);
		}

		/// <summary>PlayShouldTurnJukeboxIntoPlayingStateIfPlaylistIsNotEmpty.</summary>
		[TestMethod] public void PlayShouldTurnJukeboxIntoPlayingStateIfPlaylistIsNotEmptyTest() {
			var target = new Jukebox();
			target.Playlist.Enqueue(new Track("Beatles", "Let It Be", TrackState.Ready));
			target.Play();
			Assert.AreEqual(JukeboxState.Play, target.State);
		}

		/// <summary>PlayShouldTurnJukeboxIntoPlayingStateIfPlaylistIsNotEmpty.</summary>
		[TestMethod] public void PlayShouldTurnJukeboxIntoStopStateIfPlaylistIsEmptyTest() {
			var target = new Jukebox();
			target.Play();
			Assert.AreEqual(JukeboxState.Stop, target.State);
		}
	}
}
