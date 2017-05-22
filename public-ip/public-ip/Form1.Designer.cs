namespace public_ip
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.InternetLabel = new System.Windows.Forms.Label();
            this.PublicIPLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Internet";
            // 
            // InternetLabel
            // 
            this.InternetLabel.AutoSize = true;
            this.InternetLabel.Location = new System.Drawing.Point(83, 9);
            this.InternetLabel.Name = "InternetLabel";
            this.InternetLabel.Size = new System.Drawing.Size(94, 13);
            this.InternetLabel.TabIndex = 1;
            this.InternetLabel.Text = ".........waiting.........";
            // 
            // PublicIPLabel
            // 
            this.PublicIPLabel.AutoSize = true;
            this.PublicIPLabel.Location = new System.Drawing.Point(83, 22);
            this.PublicIPLabel.Name = "PublicIPLabel";
            this.PublicIPLabel.Size = new System.Drawing.Size(94, 13);
            this.PublicIPLabel.TabIndex = 3;
            this.PublicIPLabel.Text = ".........waiting.........";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "IP Address";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.PublicIPLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InternetLabel);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label InternetLabel;
        private System.Windows.Forms.Label PublicIPLabel;
        private System.Windows.Forms.Label label3;
    }
}

