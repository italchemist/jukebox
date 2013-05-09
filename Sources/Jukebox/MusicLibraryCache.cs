
using System;
using System.Linq;
using System.Text;

namespace Jukebox {
	using System.Collections.Generic;
	using Api;

	/// <summary>Music library cache.</summary>
	sealed class MusicLibraryCache {
		/// <summary>Returns track from search cache.</summary>
		/// <param name="key">Key.</param>
		public ITrack Get(string key) {
			ITrack track;
			_cache.TryGetValue(key, out track);
			return track;
		}

		/// <summary>Saves the tracks in cache.</summary>
		/// <param name="tracks">The tracks.</param>
		public void Save(IEnumerable<ITrack> tracks) {
			// TODO: clear old tracks
			foreach (var track in tracks) {
				_cache.Add(RandomString(8), track);
			}
		}

		static string RandomString(int length, string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789") {
			if (length < 0) throw new ArgumentOutOfRangeException("length", "length cannot be less than zero.");
			if (string.IsNullOrEmpty(allowedChars)) throw new ArgumentException("allowedChars may not be empty.");

			const int byteSize = 0x100;
			var allowedCharSet = new HashSet<char>(allowedChars).ToArray();
			if (byteSize < allowedCharSet.Length) throw new ArgumentException(String.Format("allowedChars may contain no more than {0} characters.", byteSize));

			// Guid.NewGuid and System.Random are not particularly random. By using a
			// cryptographically-secure random number generator, the caller is always
			// protected, regardless of use.
			using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider()) {
				var result = new StringBuilder();
				var buf = new byte[128];
				while (result.Length < length) {
					rng.GetBytes(buf);
					for (var i = 0; i < buf.Length && result.Length < length; ++i) {
						// Divide the byte into allowedCharSet-sized groups. If the
						// random value falls into the last group and the last group is
						// too small to choose from the entire allowedCharSet, ignore
						// the value in order to avoid biasing the result.
						var outOfRangeStart = byteSize - (byteSize % allowedCharSet.Length);
						if (outOfRangeStart <= buf[i]) continue;
						result.Append(allowedCharSet[buf[i] % allowedCharSet.Length]);
					}
				}
				return result.ToString();
			}
		}

		public string GetCacheId(ITrack track) {
			var foundTrack = _cache.FirstOrDefault(x => x.Value == track);
			return foundTrack.Value != null ? foundTrack.Key : null;
		}

		/// <summary>The cache.</summary>
		private readonly Dictionary<string, ITrack> _cache = new Dictionary<string, ITrack>();
	}
}