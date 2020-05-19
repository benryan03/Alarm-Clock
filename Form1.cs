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

        public Form1()
        {
            InitializeComponent();
            label2.Text = currentTime.ToString();
            timer1.Start();

        }

        public class dateTimeMethod
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Form1.currentTime = currentTime.AddSeconds(1);
            label2.Text = currentTime.ToString();
        }

        private void setAlarm_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            secondForm.Show();
        }
    }
}
