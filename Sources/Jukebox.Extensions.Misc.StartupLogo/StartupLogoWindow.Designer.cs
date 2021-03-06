﻿namespace Jukebox.Extensions.Misc.StartupLogo {
	partial class StartupLogoWindow {
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
			this.components = new System.ComponentModel.Container();
			this.closeWindowTimer = new System.Windows.Forms.Timer(this.components);
			this.loadingText = new System.Windows.Forms.Label();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// closeWindowTimer
			// 
			this.closeWindowTimer.Interval = 2000;
			this.closeWindowTimer.Tick += new System.EventHandler(this.OnCloseWindowTimerTick);
			// 
			// loadingText
			// 
			this.loadingText.BackColor = System.Drawing.Color.Black;
			this.loadingText.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.loadingText.ForeColor = System.Drawing.Color.White;
			this.loadingText.Location = new System.Drawing.Point(0, 238);
			this.loadingText.Name = "loadingText";
			this.loadingText.Size = new System.Drawing.Size(512, 16);
			this.loadingText.TabIndex = 1;
			this.loadingText.Text = "loading...";
			this.loadingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logoPictureBox.Image = global::Jukebox.Extensions.Misc.StartupLogo.Properties.Resources.logo2;
			this.logoPictureBox.Location = new System.Drawing.Point(0, 0);
			this.logoPictureBox.Name = "logoPictureBox";
			this.logoPictureBox.Size = new System.Drawing.Size(512, 256);
			this.logoPictureBox.TabIndex = 0;
			this.logoPictureBox.TabStop = false;
			this.logoPictureBox.Click += new System.EventHandler(this.OnLogoPictureBoxClick);
			// 
			// StartupLogoWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(512, 256);
			this.ControlBox = false;
			this.Controls.Add(this.loadingText);
			this.Controls.Add(this.logoPictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StartupLogoWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Jukebox";
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Label loadingText;
		private System.Windows.Forms.Timer closeWindowTimer;
	}
}

