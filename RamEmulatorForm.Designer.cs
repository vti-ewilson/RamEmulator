namespace RamEmulator
{
	partial class RamEmulatorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.COMPortDropdown = new System.Windows.Forms.ComboBox();
			this.connectButton = new System.Windows.Forms.Button();
			this.disconnectButton = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// COMPortDropdown
			// 
			this.COMPortDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.COMPortDropdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.COMPortDropdown.FormattingEnabled = true;
			this.COMPortDropdown.Location = new System.Drawing.Point(314, 235);
			this.COMPortDropdown.Name = "COMPortDropdown";
			this.COMPortDropdown.Size = new System.Drawing.Size(144, 40);
			this.COMPortDropdown.TabIndex = 0;
			// 
			// connectButton
			// 
			this.connectButton.Location = new System.Drawing.Point(106, 310);
			this.connectButton.Name = "connectButton";
			this.connectButton.Size = new System.Drawing.Size(150, 68);
			this.connectButton.TabIndex = 1;
			this.connectButton.Text = "Connect";
			this.connectButton.UseVisualStyleBackColor = true;
			this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
			// 
			// disconnectButton
			// 
			this.disconnectButton.Location = new System.Drawing.Point(513, 310);
			this.disconnectButton.Name = "disconnectButton";
			this.disconnectButton.Size = new System.Drawing.Size(150, 68);
			this.disconnectButton.TabIndex = 2;
			this.disconnectButton.Text = "Disconnect";
			this.disconnectButton.UseVisualStyleBackColor = true;
			this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(171, 106);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(432, 26);
			this.textBox1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(659, 84);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(98, 90);
			this.button1.TabIndex = 4;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// RamEmulatorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.disconnectButton);
			this.Controls.Add(this.connectButton);
			this.Controls.Add(this.COMPortDropdown);
			this.Name = "RamEmulatorForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.RamEmulatorForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox COMPortDropdown;
		private System.Windows.Forms.Button connectButton;
		private System.Windows.Forms.Button disconnectButton;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
	}
}

