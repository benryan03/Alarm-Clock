using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        public static DateTime currentTime = DateTime.Now;

        //public bool alarm1Expired = false;
        private string alarm1Name;
        public int panelTop = 200;

        //Up to 10 alarms can be saved
        static int x = 10;

        //public DateTime alarm1 = DateTime.MaxValue;

        public DateTime[] alarms = new DateTime[x];
        public bool[] alarmExpired = new bool[x];

        public Panel[] alarmPanels = new Panel[x];
        public Label[] alarmTitles = new Label[x];
        public Label[] alarmTimes = new Label[x];
        public Button[] alarmButtons = new Button[x];

        public Form1(string name = "")
        {
            InitializeComponent();
            label2.Text = currentTime.ToString();
            timer1.Start();

            //Populate alarm display arrays
            for (int y = 0; y < x; y++)
            {
                alarmPanels[y] = new Panel();
                alarmTitles[y] = new Label();
                alarmTimes[y] = new Label();
                alarmButtons[y] = new Button();
            }

            //Populate alarm display array values with display parameters
            for (int y = 0; y < x; y++)
            {
                Controls.Add(alarmPanels[y]);
                alarmPanels[y].Left = 15;
                alarmPanels[y].Width = 380;
                alarmPanels[y].Height = 100;
                alarmPanels[y].Visible = false;

                alarmPanels[y].Controls.Add(alarmTitles[y]);
                alarmTitles[y].Font = new Font("Microsoft Sans Serif", 18);
                alarmTitles[y].Top = 0;
                alarmTitles[y].Width = 380;

                alarmPanels[y].Controls.Add(alarmTimes[y]);
                alarmTimes[y].Font = new Font("Microsoft Sans Serif", 12);
                alarmTimes[y].Top = 25;
                alarmTimes[y].Width = 380;

                alarmPanels[y].Controls.Add(alarmButtons[y]);
                alarmButtons[y].Text = "Delete";
                alarmButtons[y].Top = 50;
            }

            //I tried all day to make this into a loop that works and I give up
            alarmButtons[0].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 0); };
            alarmButtons[1].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 1); };
            alarmButtons[2].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 2); };
            alarmButtons[3].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 3); };
            alarmButtons[4].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 4); };
            alarmButtons[5].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 5); };
            alarmButtons[6].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 6); };
            alarmButtons[7].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 7); };
            alarmButtons[8].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 8); };
            alarmButtons[9].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, 9); };

            
            //Populate alarms array with default alarm values
            for (int y = 0; y < x; y++)
            {
                alarms[y] = DateTime.MaxValue;
            }

            //Populate armExpired array with default values
            for (int y = 0; y < x; y++)
            {
                alarmExpired[y] = false;
            }
        }

        //Tick occurs once per second
        //Updates main clock display and checks if an alarm should go off
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Update main clock display
            Form1.currentTime = currentTime.AddSeconds(1);
            label2.Text = currentTime.ToString();

            for (int y = 0; y < x; y++)
            {
                if ((DateTime.Compare(alarms[y], currentTime) < 0) & alarmExpired[y] == false)
                {
                    //Show notification
                    alarmExpired[y] = true;
                    MessageBox.Show(alarmTitles[y].Text);

                    //Stop displaying that alarm
                    alarmPanels[y].Visible = false;

                    //Move the rest of the saved alarms up to fill the empty space
                    panelTop = 200;
                    foreach (Panel pnl in alarmPanels)
                    {
                        if (pnl.Visible == true)
                        {
                            pnl.Top = panelTop;
                            panelTop = panelTop + 100;
                        }
                    }
                }
            }
        }

        //Trigger when "Set Alarm" is clicked
        //But do nothing until the Set Alarm window is closed
        int newAlarmsSet = 0;
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
                alarms[newAlarmsSet] = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, minute, 0);

                //Set attributes of saved alarm display
                alarmTimes[newAlarmsSet].Text = alarms[newAlarmsSet].ToString();
                alarmTitles[newAlarmsSet].Text = alarm1Name;
                alarmPanels[newAlarmsSet].Visible = true;
                alarmPanels[newAlarmsSet].Top = panelTop;
                panelTop = panelTop + 100;

                newAlarmsSet++;
            }
        }

        //When Delete button is clicked for a saved alarm
        private void AlarmButtons_Click(object sender, EventArgs e, int z)
        {
            //Stop displaying that alarm
            alarmPanels[z].Visible = false;

            //Move the rest of the saved alarms up to fill the empty space
            panelTop = 200;
            foreach (Panel pnl in alarmPanels)
            {
                if (pnl.Visible == true)
                {
                    pnl.Top = panelTop;
                    panelTop = panelTop + 100;
                }
            }
        }
    }
}
