using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuantumVPN
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Properties.Settings.Default.connectionMethod = "tcp";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                Properties.Settings.Default.connectionMethod = "udp";
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.connectionMethod == "tcp")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (Properties.Settings.Default.connectionMethod == "udp")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.CheckForUpdates(true);
        }
    }
}
