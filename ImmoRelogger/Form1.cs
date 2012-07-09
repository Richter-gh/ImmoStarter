using System;
using System.Collections.Generic;
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
        public bool reduce = false;
        public Dictionary<int, int> temp = new Dictionary<int, int>();
        public Stopwatch sw = new Stopwatch();
        //Logging.Logger Logger = new Logging.Logger("Logger");
            
        public ImmoStarterForm()
        {
            InitializeComponent();

            //
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
            folderBrowserDialog1.ShowDialog();
            maskedTextBox1.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
            Properties.Settings.Default.im1 = maskedTextBox1.Text;
            Properties.Settings.Default.Save();
            ImmoPath[0] = maskedTextBox1.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ImmoEnabled[1] = true;
            folderBrowserDialog1.ShowDialog();
            maskedTextBox2.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
            Properties.Settings.Default.im2 = maskedTextBox2.Text;
            Properties.Settings.Default.Save();
            ImmoPath[1] = maskedTextBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ImmoEnabled[2] = true;
            folderBrowserDialog1.ShowDialog();
            maskedTextBox3.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
            ImmoPath[2] = maskedTextBox3.Text;
            Properties.Settings.Default.im3 = maskedTextBox3.Text;
            Properties.Settings.Default.Save();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ImmoEnabled[3] = true;
            folderBrowserDialog1.ShowDialog();
            maskedTextBox4.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
            ImmoPath[3] = maskedTextBox4.Text;
            Properties.Settings.Default.im4 = maskedTextBox4.Text;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ImmoEnabled[4] = true;
            folderBrowserDialog1.ShowDialog();
            maskedTextBox5.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
            ImmoPath[4] = maskedTextBox5.Text;
            Properties.Settings.Default.im5 = maskedTextBox5.Text;
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ImmoEnabled[5] = true;
            folderBrowserDialog1.ShowDialog();
            maskedTextBox6.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
            ImmoPath[5] = maskedTextBox6.Text;
            Properties.Settings.Default.im6 = maskedTextBox6.Text;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImmoEnabled[6] = true;
            folderBrowserDialog1.ShowDialog();
            maskedTextBox7.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
            ImmoPath[6] = maskedTextBox7.Text;
            Properties.Settings.Default.im7 = maskedTextBox7.Text;
            Properties.Settings.Default.Save();
        }
        #endregion
        public event EventHandler Tick;
        private static Thread tim;
        private static DispatcherTimer timer=new DispatcherTimer();
        private void StartButton_Click(object sender, EventArgs e)
        {
            
           
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

        private int counter = 0;

        public void check()
        {
            sw.Start();
            int z = 0;
            for(int i = 0; i < ImmoRunning.Length; i++) if(ImmoRunning[i]) z++;
            if(sw.Elapsed.Seconds < 10)
            {
                Thread.Sleep(1000);
            } 
            var lst = Process.GetProcessesByName("Diablo III.exe");
            foreach(KeyValuePair<int, int> a in temp)
            {
                foreach(var c in lst)
                    if(c.Id != a.Value)
                        counter++;
                    
                if(counter < z)
                    start(a.Key);
                

            }
            sw.Reset();
            check(); 
        }

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
            folderBrowserDialog1.ShowDialog();
            maskedTextBox8.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
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
            folderBrowserDialog1.ShowDialog();
            maskedTextBox9.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
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
            folderBrowserDialog1.ShowDialog();
            maskedTextBox10.Text = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.exe")[0];
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
        
        private void button16_Click(object sender, EventArgs e)
        {
            Form2 size = new Form2();
            size.ShowDialog();
            
            //int x=int.Parse(Properties.Settings.Default.length),
            //    y = int.Parse(Properties.Settings.Default.height);

            var a = Process.GetProcessesByName("Diablo III");
            //a.Reverse();
            if (Properties.Settings.Default.height == "")
            {
                Properties.Settings.Default.height = "0";
                Properties.Settings.Default.Save();
            }
            int i = int.Parse(Properties.Settings.Default.height);
            foreach (Process proc in a)
            {
                try
                {
                    SetWindowPos(proc.MainWindowHandle, this.Handle,
                 i, 0, 0, 0, SHOWWINDOW);
                   


                }
                catch (SystemException d)
                {
                    
                }
                i+=300;
                //proc.CloseMainWindow();
            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("skype:ololasek64?chat");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                reduce=true;
            else reduce=false;
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            var a = Process.GetProcessesByName("Diablo III");
            foreach (Process proc in a)
            {
                try
                {
                    if(checkBox1.Checked)
                    EmptyWorkingSet(proc.Handle);
                }
                catch (SystemException d)
                {
                }
                //proc.CloseMainWindow();
            }
        }

       

        
    }
}
