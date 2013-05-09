
namespace Jukebox.Extensions.Misc.Console {
	using System.Diagnostics;
	using System.Windows.Forms;

	/// <summary>Console window.</summary>
	public partial class ConsoleWindow : Form {
		/// <summary>Initializes a new instance of the <see cref="ConsoleWindow"/> class.</summary>
		public ConsoleWindow() {
			InitializeComponent();
			Debug.Listeners.Add(new DebugTraceListener(textBox));
		}
	}
}
