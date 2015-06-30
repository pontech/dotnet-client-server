namespace email
{
    partial class email
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
            this.button1 = new System.Windows.Forms.Button();
            this.From = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.To = new System.Windows.Forms.TextBox();
            this.Subject = new System.Windows.Forms.TextBox();
            this.Message = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // From
            // 
            this.From.Location = new System.Drawing.Point(67, 12);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(213, 20);
            this.From.TabIndex = 1;
            this.From.Text = "jacob@pontech.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "from";
            // 
            // To
            // 
            this.To.Location = new System.Drawing.Point(67, 38);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(213, 20);
            this.To.TabIndex = 3;
            this.To.Text = "mike@pontech.com";
            // 
            // Subject
            // 
            this.Subject.Location = new System.Drawing.Point(67, 64);
            this.Subject.Name = "Subject";
            this.Subject.Size = new System.Drawing.Size(213, 20);
            this.Subject.TabIndex = 4;
            this.Subject.Text = "C# e-mail test";
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(67, 90);
            this.Message.Multiline = true;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(213, 142);
            this.Message.TabIndex = 5;
            this.Message.Text = "This is a test.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "subject";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "to";
            // 
            // Username
            // 
            this.Username.Location = new System.Drawing.Point(67, 238);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(213, 20);
            this.Username.TabIndex = 10;
            this.Username.Text = "jacob@pontech.com";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(67, 264);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(213, 20);
            this.Password.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "username";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "password";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 328);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.Subject);
            this.Controls.Add(this.To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.From);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "e-mail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox From;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox To;
        private System.Windows.Forms.TextBox Subject;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
    }
}

