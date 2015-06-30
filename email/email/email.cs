using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

// Server Name	SMTP Address	    Port	SSL
// ----------------------------------------------
// Yahoo!	    smtp.mail.yahoo.com	587	    Yes
// GMail	    smtp.gmail.com	    587	    Yes
// Hotmail	    smtp.live.com	    587	    Yes

namespace email
{
    public partial class email : Form
    {
        public email()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(From.Text);
                mail.To.Add(To.Text);
                mail.Subject = Subject.Text;

                mail.IsBodyHtml = false;
                string htmlBody;

                htmlBody = Message.Text;
                mail.Body = htmlBody;


                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = true;

                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(Username.Text, Password.Text);
                smtpClient.Send(mail);

                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
