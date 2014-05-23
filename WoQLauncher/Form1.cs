using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoQLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = null;
            // Enter the executable to run, including the complete path
            start.FileName = "WoQUpdater.EXE";
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = false;

            Process proc = Process.Start(start);

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            start.Arguments = null;
            // Enter the executable to run, including the complete path
            start.FileName = "wow.EXE";
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = false;

            Process proc = Process.Start(start);

            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetVersion();
        }

        public void GetVersion()
        {
            string text = System.IO.File.ReadAllText(@"Version.woq");

            var client = new WebClient();
            string result = client.DownloadString("http://dev.woq.ca/_Zip/Remote.woq");
            label1.Text = text;

            if (text != result)
            {
                new WebClient().DownloadFile("http://dev.woq.ca/_Zip/Remote.woq", "Version.woq");
                // Prepare the process to run
                ProcessStartInfo start = new ProcessStartInfo();
                // Enter in the command line arguments, everything you would enter after the executable name itself
                start.Arguments = null;
                // Enter the executable to run, including the complete path
                start.FileName = "WoQUpdater.EXE";
                // Do you want to show a console window?
                start.WindowStyle = ProcessWindowStyle.Hidden;
                start.CreateNoWindow = false;

                Process proc = Process.Start(start);

                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Fonction à venir dans une version future du lanceur.");
        }

    }
}
