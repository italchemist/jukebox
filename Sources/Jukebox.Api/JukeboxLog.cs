
namespace Jukebox.Api {
	using System.Diagnostics;

	/// <summary>Logging interface.</summary>
	public class JukeboxLog {
		/// <summary>Writes the specified message to the log.</summary>
		/// <param name="message">The message.</param>
		public void Write(string message) {
			Debug.WriteLine(message);
		}

		/// <summary>Writes the specified message to the log.</summary>
		/// <param name="message">The message.</param>
		/// <param name="args">Arguments.</param>
		public void WriteFormat(string message, params object[] args) {
			Write(string.Format(message, args));
		}
	}
}