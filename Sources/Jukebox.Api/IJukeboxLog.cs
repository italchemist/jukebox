
namespace Jukebox.Api {
	/// <summary>Jukebox log.</summary>
	public interface IJukeboxLog {
		/// <summary>Writes the specified message to the log.</summary>
		/// <param name="message">The message.</param>
		void Write(string message);

		/// <summary>Writes the specified message to the log.</summary>
		/// <param name="message">The message.</param>
		/// <param name="args">Arguments.</param>
		void WriteFormat(string message, params object[] args);
	}
}