using System.Diagnostics;

namespace Jukebox.Extensions.Misc.Console {
	using System.Windows.Forms;

	public partial class ConsoleWindow : Form {
		/// <summary>Initializes a new instance of the <see cref="ConsoleWindow"/> class.</summary>
		public ConsoleWindow() {
			InitializeComponent();
			Debug.AutoFlush = true;
			Debug.Listeners.Add(new DebugTraceListener(textBox));
		}
	}
}
