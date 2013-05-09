
namespace Jukebox.Api {
	using System.Diagnostics;
	using System.Globalization;

	/// <summary>Logging interface.</summary>
	public class JukeboxLog : IJukeboxLog {
		/// <summary>Initializes a new instance of the <see cref="JukeboxLog"/> class.</summary>
		/// <param name="category">The category.</param>
		public JukeboxLog(string category) {
			_category = category;
		}

		/// <summary>Writes the specified message to the log.</summary>
		/// <param name="message">The message.</param>
		public void Write(string message) {
			Debug.WriteLine("{0}: {1}", _category, message);
		}

		/// <summary>Writes the specified message to the log.</summary>
		/// <param name="message">The message.</param>
		/// <param name="args">Arguments.</param>
		public void WriteFormat(string message, params object[] args) {
			Write(string.Format(CultureInfo.CurrentCulture, message, args));
		}

		/// <summary>The category.</summary>
		private readonly string _category;
	}
}