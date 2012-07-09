using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ImmoRelogger
{
    public partial class ImmoStarterForm : Form
    {
        public bool[] ImmoEnabled = { false, false, false, false, false, false, false, false, false, false };

        public string[] ImmoPath = { "", "", "", "", "", "", "", "", "", "" };

        public bool[] ImmoRunning = { false, false, false, false, false, false, false, false, false, false };

        public Thread tr;

        private bool started = false;

        private bool resized = false;

        public ImmoStarterForm()
        {
            InitializeComponent();
            SchedulerButton.Visible = checkBox2.Checked;
            #region checher
            if (Properties.Settings.Default.im1 != "")
            {
                ImmoEnabled[0] = true;

                ImmoPath[0] = Properties.Settings.Default.im1;
                maskedTextBox1.Text = ImmoPath[0];
            }
            if(Properties.Settings.Default.im2 != "")
            {
                ImmoEnabled[1] = true;

                ImmoPath[1] = Properties.Settings.Default.im2;

                maskedTextBox2.Text = ImmoPath[1];
            }
            if(Properties.Settings.Default.im3 != "")
            {
                ImmoEnabled[2] = true;

                ImmoPath[2] = Properties.Settings.Default.im3;

                maskedTextBox3.Text = ImmoPath[2];
            }
            if(Properties.Settings.Default.im4 != "")
            {
                ImmoEnabled[3] = true;

                ImmoPath[3] = Properties.Settings.Default.im4;
                maskedTextBox4.Text = ImmoPath[3];
            }
            if(Properties.Settings.Default.im5 != "")
            {
                ImmoEnabled[4] = true;

                ImmoPath[4] = Properties.Settings.Default.im5;
                maskedTextBox5.Text = ImmoPath[4];
            }
            if(Properties.Settings.Default.im6 != "")
            {
                ImmoEnabled[5] = true;

                ImmoPath[5] = Properties.Settings.Default.im6;
                maskedTextBox6.Text = ImmoPath[5];
            }
            if(Properties.Settings.Default.im7 != "")
            {
                ImmoEnabled[6] = true;

                ImmoPath[6] = Properties.Settings.Default.im7;
                maskedTextBox7.Text = ImmoPath[6];
            }
            #endregion    
        }

        #region buts
        private void button1_Click(object sender, EventArgs e)
        {
            ImmoEnabled[0] = true;
            //folderBrowserDialog1.ShowDialog();
            
            openFileDialog1.ShowDialog();
            maskedTextBox1.Text = openFileDialog1.FileName;
            Properties.Settings.Default.im1 = maskedTextBox1.Text;
            Properties.Settings.Default.Save();
            ImmoPath[0] = maskedTextBox1.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ImmoEnabled[1] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox2.Text = openFileDialog1.FileName;
            Properties.Settings.Default.im2 = maskedTextBox2.Text;
            Properties.Settings.Default.Save();
            ImmoPath[1] = maskedTextBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ImmoEnabled[2] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox3.Text = openFileDialog1.FileName;
            ImmoPath[2] = maskedTextBox3.Text;
            Properties.Settings.Default.im3 = maskedTextBox3.Text;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ImmoEnabled[3] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox4.Text = openFileDialog1.FileName;
            ImmoPath[3] = maskedTextBox4.Text;
            Properties.Settings.Default.im4 = maskedTextBox4.Text;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ImmoEnabled[4] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox5.Text = openFileDialog1.FileName;
            ImmoPath[4] = maskedTextBox5.Text;
            Properties.Settings.Default.im5 = maskedTextBox5.Text;
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImmoEnabled[5] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox6.Text = openFileDialog1.FileName;
            ImmoPath[5] = maskedTextBox6.Text;
            Properties.Settings.Default.im6 = maskedTextBox6.Text;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImmoEnabled[6] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox7.Text = openFileDialog1.FileName;
            ImmoPath[6] = maskedTextBox7.Text;
            Properties.Settings.Default.im7 = maskedTextBox7.Text;
            Properties.Settings.Default.Save();
        }
        #endregion

        private void StartButton_Click(object sender, EventArgs e)
        {
            started = true;
           
            for(int i = 0; i < 10; i++)
            {
                if (ImmoEnabled[i])
                {
                    ImmoRunning[i]=true;
                    tr=new Thread(start);
                    tr.Start(i);
                    Thread.Sleep(4000);
                }
            }
            
                
        }
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        public void start(object s)
        {
            int i=(int)s;
            
                if (ImmoPath[i] != "")
                {
                    Process.Start(ImmoPath[i]);
                    ImmoRunning[i]=true;
                    
                }
            
        }

        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc); 

        private void button8_Click(object sender, EventArgs e)
        {
            resized = false;
            var a = Process.GetProcessesByName("Diablo III");
            foreach (Process proc in a)
            {
                try
                {
                    proc.CloseMainWindow();
                }
                catch(SystemException d)
                {
                }
            }
            
        }

        #region buttons
        private void button18_Click(object sender, EventArgs e)
        {
            ImmoEnabled[7] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox8.Text = openFileDialog1.FileName;
            Properties.Settings.Default.im8 = maskedTextBox8.Text;
            Properties.Settings.Default.Save();
            ImmoPath[7] = maskedTextBox8.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ImmoEnabled[7] = false;
            maskedTextBox8.Text = "";
            Properties.Settings.Default.im8 = maskedTextBox8.Text;
            Properties.Settings.Default.Save();
            ImmoPath[7] = maskedTextBox8.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ImmoEnabled[8] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox9.Text = openFileDialog1.FileName;
            Properties.Settings.Default.im8 = maskedTextBox9.Text;
            Properties.Settings.Default.Save();
            ImmoPath[8] = maskedTextBox9.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ImmoEnabled[8] = false;
            maskedTextBox9.Text = "";
            Properties.Settings.Default.im9 = maskedTextBox9.Text;
            Properties.Settings.Default.Save();
            ImmoPath[8] = maskedTextBox9.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ImmoEnabled[9] = true;

            openFileDialog1.ShowDialog();
            maskedTextBox10.Text = openFileDialog1.FileName;
            Properties.Settings.Default.im10 = maskedTextBox10.Text;
            Properties.Settings.Default.Save();
            ImmoPath[9] = maskedTextBox10.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            ImmoEnabled[9] = false;
            maskedTextBox10.Text = "";
            Properties.Settings.Default.im10 = maskedTextBox10.Text;
            Properties.Settings.Default.Save();
            ImmoPath[9] = maskedTextBox10.Text;
        }
       
        private void button15_Click(object sender, EventArgs e)
        {
            ImmoEnabled[0] = false;
            maskedTextBox1.Text = "";
            Properties.Settings.Default.im1 = maskedTextBox1.Text;
            Properties.Settings.Default.Save();
            ImmoPath[0] = maskedTextBox1.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ImmoEnabled[1] = false;
            maskedTextBox2.Text = "";
            Properties.Settings.Default.im2 = maskedTextBox2.Text;
            Properties.Settings.Default.Save();
            ImmoPath[1] = maskedTextBox2.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ImmoEnabled[3] = false;
            maskedTextBox4.Text = "";
            Properties.Settings.Default.im4 = maskedTextBox4.Text;
            Properties.Settings.Default.Save();
            ImmoPath[3] = maskedTextBox4.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ImmoEnabled[5] = false;
            maskedTextBox6.Text = "";
            Properties.Settings.Default.im6 = maskedTextBox6.Text;
            Properties.Settings.Default.Save();
            ImmoPath[5] = maskedTextBox6.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ImmoEnabled[4] = false;
            maskedTextBox5.Text = "";
            Properties.Settings.Default.im5 = maskedTextBox5.Text;
            Properties.Settings.Default.Save();
            ImmoPath[4] = maskedTextBox5.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ImmoEnabled[6] = false;
            maskedTextBox7.Text = "";
            Properties.Settings.Default.im7 = maskedTextBox7.Text;
            Properties.Settings.Default.Save();
            ImmoPath[6] = maskedTextBox7.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ImmoEnabled[2] = false;
            maskedTextBox3.Text = "";
            Properties.Settings.Default.im3 = maskedTextBox3.Text;
            Properties.Settings.Default.Save();
            ImmoPath[2] = maskedTextBox3.Text;
        }
        #endregion

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
            int x, int y, int width, int height, uint uFlags);

        private const uint SHOWWINDOW = 0x0010;

        /// <summary>
        /// Resize button
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void button16_Click(object sender, EventArgs e)
        {
            Form2 size = new Form2();
            size.ShowDialog();
           
            var a = Process.GetProcessesByName("Diablo III");

            if (Properties.Settings.Default.height == "")
            {
                Properties.Settings.Default.height = "0";
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.Width == "")
            {
                Properties.Settings.Default.Width = "320";
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.Heigth == "")
            {
                Properties.Settings.Default.Heigth = "240";
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.Interval == "")
            {
                Properties.Settings.Default.Interval = "0";
                Properties.Settings.Default.Save();
            }
            if (Properties.Settings.Default.ScreenWidth == "")
            {
                Properties.Settings.Default.ScreenWidth = "1900";
                Properties.Settings.Default.Save();
            }
            int i = int.Parse(Properties.Settings.Default.height);
            int j = 0;
            foreach (Process proc in a)
            {
                if (int.Parse(Properties.Settings.Default.ScreenWidth)-(i+int.Parse(Properties.Settings.Default.Width))<0)
                   
                {
                    j += int.Parse(Properties.Settings.Default.Heigth);
                    i = int.Parse(Properties.Settings.Default.height);
                }
                try
                {
                    SetWindowPos(proc.MainWindowHandle, this.Handle,
                                 i, j, int.Parse(Properties.Settings.Default.Width),
                                 int.Parse(Properties.Settings.Default.Heigth), SHOWWINDOW);   

                }
                catch(SystemException d)
                {

                }
                i += int.Parse(Properties.Settings.Default.Interval);
                //if(Math.Abs(i-int.Parse(Properties.Settings.Default.ScreenWidth))>
                //    int.Parse(Properties.Settings.Default.Width))
                //{
                //    j += int.Parse(Properties.Settings.Default.Heigth);
                //    i = int.Parse(Properties.Settings.Default.height);
                //}
            }

        }

        /// <summary>
        /// Opens skype chat with me.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("skype:ololasek64?chat");
        }

        /// <summary>
        /// Reduces the memory use of Diablo windows
        /// </summary>
        private void ReduceMemoryUse()
        {
            var a = Process.GetProcessesByName("Diablo III");
            foreach (Process proc in a)
            {
                try
                {
                    EmptyWorkingSet(proc.Handle);
                }
                catch (SystemException d)
                {
                }
                
            }  
        }

        /// <summary>
        /// Checks the scheduler for doing stuff
        /// </summary>
        private void SchedulerCheck()
        {
            if(started&&!resized&&DateTime.Now.Minute==30)
            {
                int i = int.Parse(Properties.Settings.Default.height);
                if (Properties.Settings.Default.height == "")
                {
                    Properties.Settings.Default.height = "0";
                    Properties.Settings.Default.Save();
                }
                var a = Process.GetProcessesByName("Diablo III");
                foreach (Process proc in a)
                {
                    try
                    {
                        SetWindowPos(proc.MainWindowHandle, this.Handle,
                     i, 0, 320, 240, SHOWWINDOW);



                    }
                    catch (SystemException d)
                    {

                    }
                    i += 320;
                }
                resized = true;
            }
                

            switch(DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    {
                        if (!started)
                        {
                            if(DateTime.Now.Hour == Properties.Settings.Default.MondayStartHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.MondayStartMin)
                            {
                                StartButton.PerformClick();
                                started = true;
                            }
                        }
                        if (DateTime.Now.Hour == Properties.Settings.Default.MondayStopHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.MondayStopMin)
                        {
                            button8.PerformClick();
                            started = false;
                        }
                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        if (!started)
                        {
                            if (DateTime.Now.Hour == Properties.Settings.Default.TuesdayStartHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.TuesdayStartMin)
                            {
                                StartButton.PerformClick();
                                started = true;
                            }
                        }
                        if (DateTime.Now.Hour == Properties.Settings.Default.TuesdayStopHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.TuesdayStopMin)
                        {
                            button8.PerformClick();
                            started = false;
                        }
                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        if (!started)
                        {
                            if (DateTime.Now.Hour == Properties.Settings.Default.WednesdayStartHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.WednesdayStartMin)
                            {
                                StartButton.PerformClick();
                                started = true;
                            }
                        }
                        if (DateTime.Now.Hour == Properties.Settings.Default.WednesdayStopHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.WednesdayStopMin)
                        {
                            button8.PerformClick();
                            started = false;
                        }
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        if (!started)
                        {
                            if (DateTime.Now.Hour == Properties.Settings.Default.ThursdayStartHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.ThursdayStartMin)
                            {
                                StartButton.PerformClick();
                                started = true;
                            }
                        }
                        if (DateTime.Now.Hour == Properties.Settings.Default.ThursdayStopHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.ThursdayStopMin)
                        {
                            button8.PerformClick();
                            started = false;
                        }
                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        if (!started)
                        {
                            if (DateTime.Now.Hour == Properties.Settings.Default.FridayStartHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.FridayStartMin)
                            {
                                StartButton.PerformClick();
                                started = true;
                            }
                        }
                        if (DateTime.Now.Hour == Properties.Settings.Default.FridayStopHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.FridayStopMin)
                        {
                            button8.PerformClick();
                            started = false;
                        }
                        break;
                    }
                case DayOfWeek.Saturday:
                    {
                        if (!started)
                        {
                            if (DateTime.Now.Hour == Properties.Settings.Default.SaturdayStartHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.SaturdayStartMin)
                            {
                                StartButton.PerformClick();
                                started = true;
                            }
                        }
                        if (DateTime.Now.Hour == Properties.Settings.Default.SaturdayStopHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.SaturdayStopMin)
                        {
                            button8.PerformClick();
                            started = false;
                        }
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        if (!started)
                        {
                            if (DateTime.Now.Hour == Properties.Settings.Default.SundayStartHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.SundayStartMin)
                            {
                                StartButton.PerformClick();
                                started = true;
                            }
                        }
                        if (DateTime.Now.Hour == Properties.Settings.Default.SundayStopHour &&
                               DateTime.Now.Minute == Properties.Settings.Default.SundayStopMin)
                        {
                            button8.PerformClick();
                            started = false;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the Tick event of the updateTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ReduceMemoryUse();
            }
            if(checkBox2.Checked)
            {
                SchedulerCheck();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            SchedulerButton.Visible = checkBox2.Checked ? true : false;
        }

        private void SchedulerButton_Click(object sender, EventArgs e)
        {
            Form3 sched = new Form3();
            sched.ShowDialog();
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            var a = Process.GetProcessesByName("Diablo III");
            int i = 0;
            foreach (Process proc in a)
            {
                try
                {
                    SetWindowText(proc.MainWindowHandle,i.ToString(CultureInfo.InvariantCulture));
                    i++;
                }
                catch (SystemException d)
                {
                }
                //proc.CloseMainWindow();
            }
        }

        
       

        
    }
}
