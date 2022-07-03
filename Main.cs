using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ServicesApp
{
    public partial class Main : Form
    {



        string[] services = { };
        List<Button> allButtons = new List<Button>();
        string oldInputServicesText;
        int[] locationButton;

        public Main()
        {
            InitializeComponent();
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists("helpingFiles/servicesName.csv"))
            {
                services = File.ReadAllLines("helpingFiles/servicesName.csv");
                services = services.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            }
            else
            {
                Directory.CreateDirectory("helpingFiles");
                File.Create("helpingFiles/servicesName.csv").Close();
                services = new string[] { };
            }
            this.ActiveControl = null;
            this.Size = new Size(800, 550);
        }
        private void refreshFunc(bool refreshClick=false)
        {
            if (inputServices.Text != oldInputServicesText || refreshClick)
            {
                services = inputServices.Text.Split('\n');
                services = services.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                services = services.Distinct().ToArray();
                File.WriteAllLines("helpingFiles/servicesName.csv", services);
                inputServices.Clear();
                locationButton = new int[] { 20, 20 };

                try
                {
                    foreach (Button bt in allButtons) bt.Dispose();
                    allButtons.Clear();
                }
                catch (InvalidOperationException) { }

                if (services.Length == 0) return;
                foreach (string service in services)
                {

                    checkAndAppendButtons(service);
                }
                oldInputServicesText = inputServices.Text;
            }
            else
            {
                foreach (Button bt in allButtons)
                {
                    if (bt.BackColor == Color.DarkRed) bt.BackColor = Color.Red;
                    else bt.BackColor = Color.Lime;
                    bt.Enabled = true;
                }
            }
        }

        private void checkAndAppendButtons(string service)
        {
            string getService = correctCommand("cmd", $@"sc query {service}");
            inputServices.Text += service + "\n";
            if (!(getService.Contains("Указанная служба не установлена.")))
            {
                Button bt = new Button();
                bt.Text = service.Substring(0, 1).ToUpper() + service.Substring(1);
                bt.FlatStyle = FlatStyle.Flat;
                bt.FlatAppearance.BorderSize = 2;
                bt.Size = new Size(100, 40);
                bt.Location = new Point(locationButton[0], locationButton[1]);


                if (getService.Contains("STOPPED"))
                {
                    bt.BackColor = Color.Red;
                    bt.FlatAppearance.MouseOverBackColor = Color.DarkRed;
                    bt.FlatAppearance.MouseDownBackColor = Color.Crimson;
                }
                else
                {
                    bt.BackColor = Color.Lime;
                    bt.FlatAppearance.MouseOverBackColor = Color.Green;
                    bt.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
                }


                    bt.Click += buttonClick;

                this.Controls.Add(bt);
                allButtons.Add(bt);

                

                locationButton[1] += 50;
                if (allButtons.Count() % 8 == 0) { locationButton[0] += 140; locationButton[1] = 20; };
            }
        }

        private string correctCommand(string nameApp, string Com)
        { 
            Encoding utf = Encoding.GetEncoding("windows-1251");
            Encoding win = Encoding.GetEncoding("ibm866");

            Process process = new Process();
            process.StartInfo.FileName = nameApp;
            process.StartInfo.Arguments = @"/c " + Com;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
           
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();

            process.WaitForExit();
            process.Close();

            Console.Read();

            string res = utf.GetString(Encoding.Convert(win, utf, utf.GetBytes($"\n>{Com}\n{output}--------------------\n")));
            resultsCommands.Text += res;

            return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (services.Length == 0) return ;
            locationButton = new int[] {20, 20};
            foreach(string service in services)
            {
                checkAndAppendButtons(service);
            }
            oldInputServicesText = inputServices.Text;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (this.IsDisposed) return;
            string service = bt.Text;
            string output;
            if (bt.BackColor == Color.Lime)
            {
                output = correctCommand("cmd", $@"net stop {service}");
                bt.BackColor = Color.Red;
                bt.FlatAppearance.MouseOverBackColor = Color.DarkRed;
                bt.FlatAppearance.MouseDownBackColor = Color.Crimson;
            }
            else
            {
                output = correctCommand("cmd", $@"net start {service}");
                bt.BackColor = Color.Lime;
                bt.FlatAppearance.MouseOverBackColor = Color.Green;
                bt.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            }
  
           
        }

        private void seeCommandResult_CheckedChanged(object sender, EventArgs e)
        {
            if (seeCommandResult.Checked)
            {
                this.Size = new Size(1300, 550);
            }
            else
            {
                this.Size = new Size(800, 550);
            }
        }

        private void inputServices_Leave(object sender, EventArgs e)
        {
            refreshFunc();
            RefreshButton.Enabled = true;
        }

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        private void inputServices_Enter(object sender, EventArgs e)
        {
            foreach (Button bt in allButtons)
            {
                if (bt.BackColor == Color.Red) bt.BackColor = Color.DarkRed;
                else bt.BackColor = Color.Green;
                bt.Enabled = false;
            }
            RefreshButton.Enabled = false;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            refreshFunc(true);
        }
    }
}
