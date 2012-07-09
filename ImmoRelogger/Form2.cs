using System;
using System.Windows.Forms;
using ImmoRelogger.Properties;

namespace ImmoRelogger
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            heightbox.Text = Settings.Default.height;
            maskedTextBox1.Text = Settings.Default.Width;
            maskedTextBox2.Text = Settings.Default.Heigth;
            maskedTextBox3.Text = Settings.Default.Interval;
            maskedTextBox4.Text = Settings.Default.ScreenWidth;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.height = heightbox.Text;
            Settings.Default.Width = maskedTextBox1.Text;
            Settings.Default.Heigth = maskedTextBox2.Text;
            Settings.Default.Interval = maskedTextBox3.Text;
            Settings.Default.ScreenWidth = maskedTextBox4.Text;
            Settings.Default.Save();
            ActiveForm.Close();
        }


        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                Settings.Default.height = heightbox.Text;
                Settings.Default.Width = maskedTextBox1.Text;
                Settings.Default.Heigth = maskedTextBox2.Text;
                Settings.Default.Interval = maskedTextBox3.Text;
                Settings.Default.ScreenWidth = maskedTextBox4.Text;
                Settings.Default.Save();
                ActiveForm.Close();
            }
        }
    }
}