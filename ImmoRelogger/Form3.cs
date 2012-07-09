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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadSettings();
            MondayPanel.Visible = MondayCheckBox.Checked;
            TuesdayPanel.Visible = TuesdayCheckBox.Checked;
            WednesdayPanel.Visible = WednesdayCheckBox.Checked;
            ThursdayPanel.Visible = ThursdayCheckBox.Checked;
            FridayPanel.Visible = FridayCheckBox.Checked;
            SaturdayPanel.Visible = SaturdayCheckBox.Checked;
            SundayPanel.Visible = SundayCheckBox.Checked;
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        private void LoadSettings()
        {
            #region SetCheckedDays
            MondayCheckBox.Checked = Properties.Settings.Default.MondayEnabled;
            TuesdayCheckBox.Checked = Properties.Settings.Default.TuesdayEnabled;
            WednesdayCheckBox.Checked = Properties.Settings.Default.WednesdayEnabled;
            ThursdayCheckBox.Checked = Properties.Settings.Default.ThursdayEnabled;
            FridayCheckBox.Checked = Properties.Settings.Default.FridayEnabled;
            SaturdayCheckBox.Checked = Properties.Settings.Default.SaturdayEnabled;
            SundayCheckBox.Checked = Properties.Settings.Default.SundayEnabled;
            
            if (MondayCheckBox.Checked)
            {
               // Properties.Settings.Default.MondayEnabled = MondayCheckBox.Checked;
                MondayStartHourTextBox.Text=Properties.Settings.Default.MondayStartHour.ToString();
                MondayStartMinTextBox.Text=Properties.Settings.Default.MondayStartMin.ToString();
                MondayStopHourTextBox.Text=Properties.Settings.Default.MondayStopHour.ToString();
                MondayStopMinTextBox.Text=Properties.Settings.Default.MondayStopMin.ToString();
            }
            if (TuesdayCheckBox.Checked)
            {
                // Properties.Settings.Default.TuesdayEnabled = TuesdayCheckBox.Checked;
                TuesdayStartHourTextBox.Text = Properties.Settings.Default.TuesdayStartHour.ToString();
                TuesdayStartMinTextBox.Text = Properties.Settings.Default.TuesdayStartMin.ToString();
                TuesdayStopHourTextBox.Text = Properties.Settings.Default.TuesdayStopHour.ToString();
                TuesdayStopMinTextBox.Text = Properties.Settings.Default.TuesdayStopMin.ToString();
            }
            if (WednesdayCheckBox.Checked)
            {
                // Properties.Settings.Default.WednesdayEnabled = WednesdayCheckBox.Checked;
                WednesdayStartHourTextBox.Text = Properties.Settings.Default.WednesdayStartHour.ToString();
                WednesdayStartMinTextBox.Text = Properties.Settings.Default.WednesdayStartMin.ToString();
                WednesdayStopHourTextBox.Text = Properties.Settings.Default.WednesdayStopHour.ToString();
                WednesdayStopMinTextBox.Text = Properties.Settings.Default.WednesdayStopMin.ToString();
            }
            if (ThursdayCheckBox.Checked)
            {
                // Properties.Settings.Default.ThursdayEnabled = ThursdayCheckBox.Checked;
                ThursdayStartHourTextBox.Text = Properties.Settings.Default.ThursdayStartHour.ToString();
                ThursdayStartMinTextBox.Text = Properties.Settings.Default.ThursdayStartMin.ToString();
                ThursdayStopHourTextBox.Text = Properties.Settings.Default.ThursdayStopHour.ToString();
                ThursdayStopMinTextBox.Text = Properties.Settings.Default.ThursdayStopMin.ToString();
            }
            if (FridayCheckBox.Checked)
            {
                // Properties.Settings.Default.FridayEnabled = FridayCheckBox.Checked;
                FridayStartHourTextBox.Text = Properties.Settings.Default.FridayStartHour.ToString();
                FridayStartMinTextBox.Text = Properties.Settings.Default.FridayStartMin.ToString();
                FridayStopHourTextBox.Text = Properties.Settings.Default.FridayStopHour.ToString();
                FridayStopMinTextBox.Text = Properties.Settings.Default.FridayStopMin.ToString();
            }
            if (SaturdayCheckBox.Checked)
            {
                // Properties.Settings.Default.SaturdayEnabled = SaturdayCheckBox.Checked;
                SaturdayStartHourTextBox.Text = Properties.Settings.Default.SaturdayStartHour.ToString();
                SaturdayStartMinTextBox.Text = Properties.Settings.Default.SaturdayStartMin.ToString();
                SaturdayStopHourTextBox.Text = Properties.Settings.Default.SaturdayStopHour.ToString();
                SaturdayStopMinTextBox.Text = Properties.Settings.Default.SaturdayStopMin.ToString();
            }
            if (SundayCheckBox.Checked)
            {
                // Properties.Settings.Default.SundayEnabled = SundayCheckBox.Checked;
                SundayStartHourTextBox.Text = Properties.Settings.Default.SundayStartHour.ToString();
                SundayStartMinTextBox.Text = Properties.Settings.Default.SundayStartMin.ToString();
                SundayStopHourTextBox.Text = Properties.Settings.Default.SundayStopHour.ToString();
                SundayStopMinTextBox.Text = Properties.Settings.Default.SundayStopMin.ToString();
            }
            #endregion
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        private void SaveSettings()
        {
            #region CheckCheckedDays
            if (MondayCheckBox.Checked)
            {
                Properties.Settings.Default.MondayEnabled = MondayCheckBox.Checked;
                Properties.Settings.Default.MondayStartHour = int.Parse(MondayStartHourTextBox.Text);
                Properties.Settings.Default.MondayStartMin = int.Parse(MondayStartMinTextBox.Text);
                Properties.Settings.Default.MondayStopHour = int.Parse(MondayStopHourTextBox.Text);
                Properties.Settings.Default.MondayStopMin = int.Parse(MondayStopMinTextBox.Text);
            }
            if (TuesdayCheckBox.Checked)
            {
                Properties.Settings.Default.TuesdayEnabled = TuesdayCheckBox.Checked;
                Properties.Settings.Default.TuesdayStartHour = int.Parse(TuesdayStartHourTextBox.Text);
                Properties.Settings.Default.TuesdayStartMin = int.Parse(TuesdayStartMinTextBox.Text);
                Properties.Settings.Default.TuesdayStopHour = int.Parse(TuesdayStopHourTextBox.Text);
                Properties.Settings.Default.TuesdayStopMin = int.Parse(TuesdayStopMinTextBox.Text);
            }
            if (WednesdayCheckBox.Checked)
            {
                Properties.Settings.Default.WednesdayEnabled = WednesdayCheckBox.Checked;
                Properties.Settings.Default.WednesdayStartHour = int.Parse(WednesdayStartHourTextBox.Text);
                Properties.Settings.Default.WednesdayStartMin = int.Parse(WednesdayStartMinTextBox.Text);
                Properties.Settings.Default.WednesdayStopHour = int.Parse(WednesdayStopHourTextBox.Text);
                Properties.Settings.Default.WednesdayStopMin = int.Parse(WednesdayStopMinTextBox.Text);
            }
            if (ThursdayCheckBox.Checked)
            {
                Properties.Settings.Default.ThursdayEnabled = ThursdayCheckBox.Checked;
                Properties.Settings.Default.ThursdayStartHour = int.Parse(ThursdayStartHourTextBox.Text);
                Properties.Settings.Default.ThursdayStartMin = int.Parse(ThursdayStartMinTextBox.Text);
                Properties.Settings.Default.ThursdayStopHour = int.Parse(ThursdayStopHourTextBox.Text);
                Properties.Settings.Default.ThursdayStopMin = int.Parse(ThursdayStopMinTextBox.Text);
            }
            if (FridayCheckBox.Checked)
            {
                Properties.Settings.Default.FridayEnabled = FridayCheckBox.Checked;
                Properties.Settings.Default.FridayStartHour = int.Parse(FridayStartHourTextBox.Text);
                Properties.Settings.Default.FridayStartMin = int.Parse(FridayStartMinTextBox.Text);
                Properties.Settings.Default.FridayStopHour = int.Parse(FridayStopHourTextBox.Text);
                Properties.Settings.Default.FridayStopMin = int.Parse(FridayStopMinTextBox.Text);
            }
            if (SaturdayCheckBox.Checked)
            {
                Properties.Settings.Default.SaturdayEnabled = SaturdayCheckBox.Checked;
                Properties.Settings.Default.SaturdayStartHour = int.Parse(SaturdayStartHourTextBox.Text);
                Properties.Settings.Default.SaturdayStartMin = int.Parse(SaturdayStartMinTextBox.Text);
                Properties.Settings.Default.SaturdayStopHour = int.Parse(SaturdayStopHourTextBox.Text);
                Properties.Settings.Default.SaturdayStopMin = int.Parse(SaturdayStopHourTextBox.Text);
            }
            if (SundayCheckBox.Checked)
            {
                Properties.Settings.Default.SundayEnabled = SundayCheckBox.Checked;
                Properties.Settings.Default.SundayStartHour = int.Parse(SundayStartHourTextBox.Text);
                Properties.Settings.Default.SundayStartMin = int.Parse(SundayStartMinTextBox.Text);
                Properties.Settings.Default.SundayStopHour = int.Parse(SundayStopHourTextBox.Text);
                Properties.Settings.Default.SundayStopMin = int.Parse(SundayStopMinTextBox.Text);
            }
#endregion

            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveSettings();
            ActiveForm.Close();
        } 
        
        #region DayOfWeekCheckBox
        private void MondayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MondayPanel.Visible = MondayCheckBox.Checked;
        }

        private void TuesdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TuesdayPanel.Visible = TuesdayCheckBox.Checked;
        }

        private void WednesdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            WednesdayPanel.Visible = WednesdayCheckBox.Checked;
        }

        private void ThursdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ThursdayPanel.Visible = ThursdayCheckBox.Checked;
        }

        private void FridayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FridayPanel.Visible = FridayCheckBox.Checked;
        }

        private void SaturdayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SaturdayPanel.Visible = SaturdayCheckBox.Checked;
        }

        private void SundayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SundayPanel.Visible = SundayCheckBox.Checked;
        }
        #endregion

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
