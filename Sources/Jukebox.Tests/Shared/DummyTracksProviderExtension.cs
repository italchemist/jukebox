
namespace Jukebox.Tests.Shared {
	using System.Collections.Generic;
	using System.Linq;
	using Api;

	class DummyTracksProviderExtension : Extension {
		public DummyTracksProviderExtension() {
			_tracks = new List<ITrack> {
				new Track("Beatles", "Yellow Submarine"),
				new Track("Beatles", "Let It Be")
			};
		}
		
		public override IEnumerable<ITrack> OnSearch(string query) {
			return _tracks.Where(x =>
				x.Performer.ToLower().Contains(query.ToLower()) ||
				x.Title.ToLower().Contains(query.ToLower()));
		}

		private List<ITrack> _tracks;
	}
}
