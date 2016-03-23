using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace Spotify_Downloader
{
    public partial class Form1 : Form
    {
        public object Tools { get; private set; }
        public int c { get; private set; }
        public object cmd { get; private set; }
        public int C { get; private set; }
        public object pause { get; private set; }

        public Form1()
        {
            InitializeComponent();

        }

        string OutputData;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText("readmegui.txt");






        }


        private void button2_Click_2(object sender, EventArgs e)
        {

            Process npm = new Process();
            npm.StartInfo.FileName = @"C:\Program Files\nodejs\npm.cmd";
            npm.StartInfo.Arguments = "install";
            npm.StartInfo.UseShellExecute = false;
            npm.StartInfo.RedirectStandardOutput = true;
            npm.Start();
            richTextBox1.Text = npm.StandardOutput.ReadToEnd();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string[] lines = File.ReadAllLines("main.js");
            lines[23] = string.Format("USERNAME = \"{0}\"", textBox1.Text);
            lines[25] = string.Format("PASSWORD = \"{0}\"", textBox5.Text);
            File.WriteAllLines("main.js", lines);
            textBox5.Text = String.Empty;
            MessageBox.Show("Login Saved", "Login", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText("readmegui.txt");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }




        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;

            if (!string.IsNullOrWhiteSpace(textBox6.Text))

            {
                string text = textBox6.Text;
                Match match = Regex.Match(text, @"https://play.spotify.com/user/([A-Za-z0-9_\-]+)/playlist/([A-Za-z0-9_\-]+)");
                string user = match.Groups[1].Value;
                string playlist = match.Groups[2].Value;

                if (checkBox1.Checked)

                {
                    Process dnlf = new Process();
                    dnlf.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnlf.StartInfo.Arguments = string.Format("main.js -f -u {0} -p {1}", user, playlist);
                    dnlf.StartInfo.UseShellExecute = false;
                    dnlf.StartInfo.RedirectStandardOutput = true;
                    dnlf.EnableRaisingEvents = true;
                    dnlf.StartInfo.CreateNoWindow = true;
                    dnlf.OutputDataReceived += OnOutputDataReceived;
                    dnlf.Start();
                    dnlf.BeginOutputReadLine();

                    while (!dnlf.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }

                }

                else if (!checkBox1.Checked)
                {

                    Process dnl = new Process();
                    dnl.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnl.StartInfo.Arguments = string.Format("main.js -u {0} -p {1}", user, playlist);
                    dnl.StartInfo.UseShellExecute = false;
                    dnl.StartInfo.RedirectStandardOutput = true;
                    dnl.EnableRaisingEvents = true;
                    dnl.StartInfo.CreateNoWindow = true;
                    dnl.Exited += new EventHandler(process_Exited);
                    dnl.OutputDataReceived += OnOutputDataReceived;
                    dnl.Start();
                    dnl.BeginOutputReadLine();

                    while (!dnl.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }





                }







                else
                {
                    MessageBox.Show("You must at least fill in 1 playlist", "Playlist ERROR", MessageBoxButtons.OK);


                }
            }
        
    
            if (!string.IsNullOrWhiteSpace(textBox2.Text))

            {
                string text2 = textBox2.Text;
                Match match2 = Regex.Match(text2, @"https://play.spotify.com/user/([A-Za-z0-9_\-.]+)/playlist/([A-Za-z0-9_\-.]+)");
                string user2 = match2.Groups[1].Value;
                string playlist2 = match2.Groups[2].Value;

                if (checkBox1.Checked)

                {
                    Process dnlf = new Process();
                    dnlf.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnlf.StartInfo.Arguments = string.Format("main.js -f -u {0} -p {1}", user2, playlist2);
                    dnlf.StartInfo.UseShellExecute = false;
                    dnlf.StartInfo.RedirectStandardOutput = true;
                    dnlf.EnableRaisingEvents = true;
                    dnlf.StartInfo.CreateNoWindow = true;
                    dnlf.OutputDataReceived += OnOutputDataReceived;
                    dnlf.Start();
                    dnlf.BeginOutputReadLine();

                    while (!dnlf.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }


                }

                else if (!checkBox1.Checked)
                {
                    Process dnl = new Process();
                    dnl.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnl.StartInfo.Arguments = string.Format("main.js -u {0} -p {1}", user2, playlist2);
                    dnl.StartInfo.UseShellExecute = false;
                    dnl.StartInfo.RedirectStandardOutput = true;
                    dnl.EnableRaisingEvents = true;
                    dnl.StartInfo.CreateNoWindow = true;
                    dnl.OutputDataReceived += OnOutputDataReceived;
                    dnl.Start();
                    dnl.BeginOutputReadLine();

                    while (!dnl.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }


                }
                else
                {

                }

            }
           if (!string.IsNullOrWhiteSpace(textBox3.Text))

              {
                        string text3 = textBox3.Text;
                        Match match3 = Regex.Match(text3, @"https://play.spotify.com/user/([A-Za-z0-9_\-]+)/playlist/([A-Za-z0-9_\-]+)");
                        string user3 = match3.Groups[1].Value;
                        string playlist3 = match3.Groups[2].Value;

                if (checkBox1.Checked)

                {
                    Process dnlf = new Process();
                    dnlf.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnlf.StartInfo.Arguments = string.Format("main.js -f -u {0} -p {1}", user3, playlist3);
                    dnlf.StartInfo.UseShellExecute = false;
                    dnlf.StartInfo.RedirectStandardOutput = true;
                    dnlf.EnableRaisingEvents = true;
                    dnlf.StartInfo.CreateNoWindow = true;
                    dnlf.OutputDataReceived += OnOutputDataReceived;
                    dnlf.Start();
                    dnlf.BeginOutputReadLine();

                    while (!dnlf.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }

                }

                else if (!checkBox1.Checked)
                {
                    Process dnl = new Process();
                    dnl.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnl.StartInfo.Arguments = string.Format("main.js -u {0} -p {1}", user3, playlist3);
                    dnl.StartInfo.UseShellExecute = false;
                    dnl.StartInfo.RedirectStandardOutput = true;
                    dnl.EnableRaisingEvents = true;
                    dnl.StartInfo.CreateNoWindow = true;
                    dnl.OutputDataReceived += OnOutputDataReceived;
                    dnl.Start();
                    dnl.BeginOutputReadLine();

                    while (!dnl.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }




                 }

                else
                {


                }

            }

            if (!string.IsNullOrWhiteSpace(textBox4.Text))

            {
                string text4 = textBox4.Text;
                Match match4 = Regex.Match(text4, @"https://play.spotify.com/user/([A-Za-z0-9_\-]+)/playlist/([A-Za-z0-9_\-]+)");
                string user4 = match4.Groups[1].Value;
                string playlist4 = match4.Groups[2].Value;

                if (checkBox1.Checked)

                {
                    Process dnlf = new Process();
                    dnlf.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnlf.StartInfo.Arguments = string.Format("main.js -f -u {0} -p {1}", user4, playlist4);
                    dnlf.StartInfo.UseShellExecute = false;
                    dnlf.StartInfo.RedirectStandardOutput = true;
                    dnlf.EnableRaisingEvents = true;
                    dnlf.StartInfo.CreateNoWindow = true;
                    dnlf.OutputDataReceived += OnOutputDataReceived;
                    dnlf.Start();
                    dnlf.BeginOutputReadLine();

                    while (!dnlf.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }

                }

                else if (!checkBox1.Checked)
                {
                    Process dnl = new Process();
                    dnl.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                    dnl.StartInfo.Arguments = string.Format("main.js -u {0} -p {1}", user4, playlist4);
                    dnl.StartInfo.UseShellExecute = false;
                    dnl.StartInfo.RedirectStandardOutput = true;
                    dnl.EnableRaisingEvents = true;
                    dnl.StartInfo.CreateNoWindow = true;
                    dnl.OutputDataReceived += OnOutputDataReceived;
                    dnl.Start();
                    dnl.BeginOutputReadLine();

                    while (!dnl.HasExited)
                    {
                        Application.DoEvents();
                        Thread.Sleep(1);
                    }
                }
                else

                {



                }

            }

                if (!string.IsNullOrWhiteSpace(textBox7.Text))

                {
                    string text5 = textBox7.Text;
                    Match match5 = Regex.Match(text5, @"https://play.spotify.com/user/([A-Za-z0-9_\-]+)/playlist/([A-Za-z0-9_\-]+)");
                    string user5 = match5.Groups[1].Value;
                    string playlist5 = match5.Groups[2].Value;

                    if (checkBox1.Checked)

                    {
                        Process dnlf = new Process();
                        dnlf.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                        dnlf.StartInfo.Arguments = string.Format("main.js -f -u {0} -p {1}", user5, playlist5);
                        dnlf.StartInfo.UseShellExecute = false;
                        dnlf.StartInfo.RedirectStandardOutput = true;
                        dnlf.EnableRaisingEvents = true;
                        dnlf.StartInfo.CreateNoWindow = true;
                        dnlf.OutputDataReceived += OnOutputDataReceived;
                        dnlf.Start();
                        dnlf.BeginOutputReadLine();

                        while (!dnlf.HasExited)
                        {
                            Application.DoEvents();
                            Thread.Sleep(1);
                        }

                    }

                    else if (!checkBox1.Checked)
                    {
                        Process dnl = new Process();
                        dnl.StartInfo.FileName = @"C:\Program Files\nodejs\node.exe";
                        dnl.StartInfo.Arguments = string.Format("main.js -u {0} -p {1}", user5, playlist5);
                        dnl.StartInfo.UseShellExecute = false;
                        dnl.StartInfo.RedirectStandardOutput = true;
                        dnl.EnableRaisingEvents = true;
                        dnl.StartInfo.CreateNoWindow = true;
                        dnl.OutputDataReceived += OnOutputDataReceived;
                        dnl.Start();
                        dnl.BeginOutputReadLine();

                        while (!dnl.HasExited)
                        {
                            Application.DoEvents();
                            Thread.Sleep(1);
                        }
                    }
                    else

                    {



                    }

                
            }

           if (checkBox2.Checked)

            {
                string[] lines = File.ReadAllLines("main.js");
                lines[25] = string.Format("PASSWORD = \"\"");
                File.WriteAllLines("main.js", lines);

            }

           else if (!checkBox2.Checked)
            {



            }
        }
        void process_Exited(object sender, EventArgs e)
        {
            Process dnl = (Process)sender;
            int exitCode = dnl.ExitCode;
        }

        void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.OutputData += e.Data + Environment.NewLine;
                SetText(this.OutputData);
            }
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.Text = text;
            }

        }
       
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            
            richTextBox1.ScrollToCaret();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
