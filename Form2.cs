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
        }


    }
}
