
namespace Jukebox.Tests {
	using System.Collections.Generic;
	using Api;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Shared;


	/// <summary>This is a test class for MusicLibraryTest and is intended to contain all MusicLibraryTest Unit Tests</summary>
	[TestClass] public class MusicLibraryTest {
		/// <summary>Search on empty music library should return an empty collection.</summary>
		[TestMethod] public void SearchOnEmptyMusicLibraryShouldReturnEmptyCollectionTest() {
			var target = new MusicLibrary();
			var query = string.Empty;
			var actual = new List<ITrack>(target.Search(query));
			Assert.AreEqual(0, actual.Count);
		}


		/// <summary>Non empty music library should return tracks.</summary>
		[TestMethod] public void NonEmptyMusicLibraryShouldReturnTracksIfFoundTest() {
			var target = new MusicLibrary();
			var tracksProvider = new DummyTracksProviderExtension();
			target.AddTracksProvider(tracksProvider);
			var tracks = new List<ITrack>(target.Search("beatles"));
			Assert.AreNotEqual(0, tracks.Count);
		}

		/// <summary>Non empty music library should return empty collection if nothing found.</summary>
		[TestMethod] public void NonEmptyMusicLibraryShouldReturnEmptyCollectionTracksIfNothingFoundTest() {
			var target = new MusicLibrary();
			var tracksProvider = new DummyTracksProviderExtension();
			target.AddTracksProvider(tracksProvider);
			var tracks = new List<ITrack>(target.Search("!@#$%^&something!@#$%^"));
			Assert.AreEqual(0, tracks.Count);
		}
	}
}
