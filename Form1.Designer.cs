
namespace QuantumVPN
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.connectedText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.versionLabel);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-20, -12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 472);
            this.panel1.TabIndex = 0;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(22, 332);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(0, 20);
            this.versionLabel.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(65, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantum";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(389, 191);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(115, 34);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sydney_1",
            "Custom .OVPN Connection"});
            this.comboBox1.Location = new System.Drawing.Point(345, 137);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 28);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "Select your server";
            // 
            // connectedText
            // 
            this.connectedText.AutoSize = true;
            this.connectedText.Font = new System.Drawing.Font("Roboto Light", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.connectedText.Location = new System.Drawing.Point(345, 67);
            this.connectedText.Name = "connectedText";
            this.connectedText.Size = new System.Drawing.Size(205, 37);
            this.connectedText.TabIndex = 3;
            this.connectedText.Text = "Not connected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 343);
            this.Controls.Add(this.connectedText);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantum";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label connectedText;
        private System.Windows.Forms.Label versionLabel;
    }
}

