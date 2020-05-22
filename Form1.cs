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
                MessageBox.Show("Alarm!");
            }

        }

        private void setAlarm_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                //Get and format the alarm time that the user set
                int hour = 0;
                int minute = int.Parse(f.SetMinute);
                if (f.SetHalf == "AM")
                {
                    hour = int.Parse(f.SetHour);
                    if (f.SetHour == "12")
                    {
                        hour = 0;
                    }
                }
                else if (f.SetHalf == "PM")
                {
                    hour = int.Parse(f.SetHour) + 12;
                }

                alarm1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, minute, 0);
                
                if ( DateTime.Compare(alarm1, currentTime) < 0)
                {
                    label3.Text = "alarm cannot be in the past";
                    alarm1 = DateTime.MaxValue;
                }
                else
                {
                    label3.Text = f.Name + " " + alarm1;
                }
            }
        }
    }
}
