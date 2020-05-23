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
    public partial class Form2 : Form
    {
        public DateTime alarm1 = DateTime.MaxValue;

        private string setHour;
        public string SetHour
        {
            get { return setHour; }
            set { setHour = value; }
        }

        private string setMinute;
        public string SetMinute
        {
            get { return setMinute; }
            set { setMinute = value; }
        }

        private string setHalf;
        public string SetHalf
        {
            get { return setHalf; }
            set { setHalf = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SetHour = comboBox1.Text;
            SetMinute = comboBox2.Text;
            SetHalf = comboBox3.Text;
            Name = textBox1.Text;

            DateTime currentTime = DateTime.Now;

            //Get and format the alarm time that the user set
            int hour = 0;
            int minute = int.Parse(SetMinute);
            if (SetHalf == "AM")
            {
                hour = int.Parse(SetHour);
                if (SetHour == "12")
                {
                    hour = 0;
                }
            }
            else if (SetHalf == "PM")
            {
                hour = int.Parse(SetHour) + 12;
            }

            alarm1 = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, hour, minute, 0);
            if (alarm1 < currentTime)
            {
                MessageBox.Show("Alarm cannot be in the past");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
