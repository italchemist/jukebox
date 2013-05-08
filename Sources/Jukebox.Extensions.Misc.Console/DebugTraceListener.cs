
namespace Jukebox.Extensions.Misc.Console {
	using System;
	using System.Diagnostics;
	using System.Windows.Forms;
	
	public class DebugTraceListener : TraceListener {
		/// <summary>Initializes a new instance of the <see cref="DebugTraceListener"/> class.</summary>
		/// <param name="textBox">The text box.</param>
		public DebugTraceListener(RichTextBox textBox) {
			_textBox = textBox;
		}

		/// <summary>When overridden in a derived class, writes the specified message to the listener you create in the derived class.</summary>
		/// <param name="message">A message to write.</param>
		public override void Write(string message) {
			if (_textBox.InvokeRequired) {
				var d = new WriteCallback(Write);
				_textBox.Invoke(d, new object[] { message });
			} else {
				_textBox.AppendText(message);
			}
			
		}

		/// <summary>When overridden in a derived class, writes a message to the listener you create in the derived class, followed by a line terminator.</summary>
		/// <param name="message">A message to write.</param>
		public override void WriteLine(string message) {
			Write(message + Environment.NewLine);
		}

		/// <summary>Set loading text callback.</summary>
		/// <param name="message">The text.</param>
		private delegate void WriteCallback(string message);

		/// <summary>The text box.</summary>
		private readonly RichTextBox _textBox;
	}
}