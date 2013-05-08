namespace Jukebox.Extensions.Misc.Console {
	partial class ConsoleWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.textBox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.BackColor = System.Drawing.Color.Black;
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox.ForeColor = System.Drawing.Color.White;
			this.textBox.Location = new System.Drawing.Point(0, 0);
			this.textBox.Name = "textBox";
			this.textBox.ReadOnly = true;
			this.textBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.textBox.Size = new System.Drawing.Size(592, 273);
			this.textBox.TabIndex = 0;
			this.textBox.Text = "";
			this.textBox.WordWrap = false;
			// 
			// ConsoleWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 273);
			this.Controls.Add(this.textBox);
			this.Name = "ConsoleWindow";
			this.ShowIcon = false;
			this.Text = "Jukebox Console";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox textBox;
	}
}