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
using System.Security;


namespace ServicesApp
{
    public partial class Main : Form
    {



        string[] services = { };        
        public Main()
        {
            InitializeComponent();
            var exePath = AppDomain.CurrentDomain.BaseDirectory;
            services = File.ReadAllLines("helpingFiles/servicesName.csv");



        }

        private string correctCommand(string nameApp, string Com)
        { 
            Encoding utf = Encoding.GetEncoding("windows-1251");
            Encoding win = Encoding.GetEncoding("ibm866");

            Process process = new Process();
            process.StartInfo.FileName = nameApp;
            process.StartInfo.Arguments = Com;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
           
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();

            process.WaitForExit();
            process.Close();

            Console.Read();

            return utf.GetString(Encoding.Convert(win, utf, utf.GetBytes(output)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int[] locationButton = { 20, 20 };
            int buttonCount = 0;
            foreach(string service in services)
            {
                string getService = correctCommand("cmd", $@"/c sc query {service}");
                resultsCommands.Text += "\n" + getService + "----------\n";
                if (!(getService.Contains("Указанная служба не установлена.")))
                {
                    Button bt = new Button();
                    bt.Text =  service.Substring(0, 1).ToUpper() + service.Substring(1);
                    bt.FlatStyle = FlatStyle.Flat;
                    bt.FlatAppearance.BorderSize = 2;
                    bt.Size = new Size(100, 40);
                    bt.Location = new Point(locationButton[0], locationButton[1]);

                    if (getService.Contains("STOPPED")) bt.BackColor = Color.Red;
                    else bt.BackColor = Color.Lime;

                    bt.Click += buttonClick;

                    this.Controls.Add(bt);

                    inputServices.Text += service + "\n";

                    locationButton[1] += 60;
                    buttonCount++;
                    if (buttonCount % 5 == 0) { locationButton[0] += 140; locationButton[1] = 20; };
                }
            }
            
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string service = bt.Text;
            string output;
            if (bt.BackColor == Color.Lime)
            {
                output = correctCommand("cmd", $@"/c net stop {service}");
                bt.BackColor = Color.Red;
               
            }
            else
            {
                output = correctCommand("cmd", $@"/c net start {service}");
                bt.BackColor = Color.Lime;
                
            }
  
            resultsCommands.Text += "\n" + output + "----------\n";
        }
    }
}
