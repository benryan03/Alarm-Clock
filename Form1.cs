using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public static DateTime currentTime = DateTime.Now;
        public DateTime alarm1 = DateTime.MaxValue;

        public bool alarm1Expired = false;
        private string alarm1Name;
        public int panelTop = 100;

        Panel alarmPanel1 = new Panel();
        Label alarm1Title = new Label();
        Label alarm1Time = new Label();
        Button alarm1Delete = new Button();


        public Form1(string name = "")
        {
            InitializeComponent();
            label2.Text = currentTime.ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1.currentTime = currentTime.AddSeconds(1);
            label2.Text = currentTime.ToString();

            if ((DateTime.Compare(alarm1, currentTime) < 0) & alarm1Expired == false)
            {
                alarm1Expired = true;
                MessageBox.Show(alarm1Name);
            }
        }

        private void setAlarm_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            
            //If a new alarm was set on Form2
            if (f.ShowDialog() == DialogResult.OK)
            {
                //Get and format the alarm time that the user set
                int hour = int.Parse(f.SetHour);
                int minute = int.Parse(f.SetMinute);
                alarm1Name = f.Name;
                alarm1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, minute, 0);

                panelTop = panelTop + 100;

                //Display the saved alarms

                this.Controls.Add(alarmPanel1);
                //alarmPanel1.BackColor = Color.White;  //Debug
                alarmPanel1.Top = panelTop;
                alarmPanel1.Left = 15;
                alarmPanel1.Width = 380;
                alarmPanel1.Height = 100;

                alarmPanel1.Controls.Add(alarm1Title);
                alarm1Title.Text = f.Name;
                alarm1Title.Font = new Font("Microsoft Sans Serif", 18);
                alarm1Title.Top = 0;

                alarmPanel1.Controls.Add(alarm1Time);
                alarm1Time.Text = alarm1.ToString();
                alarm1Time.Font = new Font("Microsoft Sans Serif", 12);
                alarm1Time.Top = 25;
                alarm1Time.Width = 380;

                alarmPanel1.Controls.Add(alarm1Delete);
                alarm1Delete.Text = "Delete";
                alarm1Delete.Top = 50;
                alarm1Delete.Click += new EventHandler(alarm1Delete_Click);
            }
        }

        private void alarm1Delete_Click(object sender, EventArgs e)
        {
            alarmPanel1.Controls.Remove(alarmPanel1);
            alarmPanel1.Controls.Remove(alarm1Title);
            alarmPanel1.Controls.Remove(alarm1Time);
            alarmPanel1.Controls.Remove(alarm1Delete);
        }
    }
}
