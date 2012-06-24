using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImmoRelogger
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.height = heightbox.Text;
            //Properties.Settings.Default.length = lengthbox.Text;
            Properties.Settings.Default.Save();
            ActiveForm.Close();
        }
        

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Properties.Settings.Default.height = heightbox.Text;
                //Properties.Settings.Default.length = lengthbox.Text;
                Properties.Settings.Default.Save();
                ActiveForm.Close();
            }
        }
    }
}
