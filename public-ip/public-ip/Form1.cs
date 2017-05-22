using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace public_ip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static string PublicIP()
        {
            try
            {
                WebClient client = new WebClient();
                string IP = client.DownloadString("http://icanhazip.com/");
                return IP;
            }
            catch
            {
                return "unknown";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InternetLabel.Text = CheckForInternetConnection().ToString();
            PublicIPLabel.Text  = PublicIP();
            timer1.Enabled = false;
        }
    }
}
