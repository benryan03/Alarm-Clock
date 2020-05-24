﻿using System;
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
        public DateTime alarm1 = DateTime.MaxValue;

        public bool alarm1Expired = false;
        private string alarm1Name;
        public int panelTop = 200;

        //Up to 10 alarms can be saved
        static int x = 10;

        Panel[] alarmPanels = new Panel[x];
        Label[] alarmTitles = new Label[x];
        Label[] alarmTimes = new Label[x];
        Button[] alarmButtons = new Button[x];

        public Form1(string name = "")
        {
            InitializeComponent();
            label2.Text = currentTime.ToString();
            timer1.Start();

            //Populate stuff for saved alarms display
            for (int y = 0; y < x; y++)
            {
                alarmPanels[y] = new Panel();
                alarmTitles[y] = new Label();
                alarmTimes[y] = new Label();
                alarmButtons[y] = new Button();
            }

            for (int y = 0; y < x; y++)
            {
                Controls.Add(alarmPanels[y]);
                alarmPanels[y].BackColor = Color.White;  //Debug
                //alarmPanels[y].Top = panelTop;
                alarmPanels[y].Left = 15;
                alarmPanels[y].Width = 380;
                alarmPanels[y].Height = 100;
                alarmPanels[y].Visible = false;

                alarmPanels[y].Controls.Add(alarmTitles[y]);
                //alarmTitles[y].Text = f.Name;
                alarmTitles[y].Font = new Font("Microsoft Sans Serif", 18);
                alarmTitles[y].Top = 0;

                alarmPanels[y].Controls.Add(alarmTimes[y]);
                //alarmTimes[y].Text = alarm1.ToString();
                alarmTimes[y].Text = y.ToString();
                alarmTimes[y].Font = new Font("Microsoft Sans Serif", 12);
                alarmTimes[y].Top = 25;
                alarmTimes[y].Width = 380;

                alarmPanels[y].Controls.Add(alarmButtons[y]);
                alarmButtons[y].Text = "Delete";
                alarmButtons[y].Top = 50;
                //alarmButtons[y].Click += new EventHandler(AlarmButtons_Click(y));
            }
        }

        //Tick occurs once per second
        //Updates main clock display and checks if an alarm should go off
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
                alarm1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, minute, 0);

                alarmPanels[newAlarmsSet].Visible = true;
                alarmPanels[newAlarmsSet].Top = panelTop;
                panelTop = panelTop + 100;

                alarmButtons[newAlarmsSet].Click += (sender2, EventArgs) => { AlarmButtons_Click(sender2, EventArgs, newAlarmsSet); };

                newAlarmsSet++;
            }
        }

        private void AlarmButtons_Click(object sender, EventArgs e, int test)
        {
            MessageBox.Show(test.ToString());
            //return 1;
        }
    }
}
