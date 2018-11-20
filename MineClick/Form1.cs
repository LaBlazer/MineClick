using System;
using System.Windows.Forms;

namespace MineClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Window mcWindow;
        private Window[] windows;
        private System.Timers.Timer clickTimer = new System.Timers.Timer();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                clickTimer.Enabled = true;
                clickTimer.Interval = 20000;
                clickTimer.Elapsed += clickTimer_Elapsed;

                button1.Enabled = false;
                button2.Enabled = true;

                mcWindow.SendMessage(Window.WM_RBUTTONDOWN, 0x00000001, 0x1E5025B);
                mcWindow.Minimize();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }

        void clickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            mcWindow.SendMessage(Window.WM_RBUTTONDOWN, 0x00000001, 0x1E5025B);
            mcWindow.Minimize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            do
            {
                windows = WindowHelper.Find(0, "Minecraft", "GLFW30");
                if (windows.Length == 0)
                {
                    var res = MessageBox.Show("Minecraft is not running, please run Minecraft and press Retry", "Whoops", MessageBoxButtons.RetryCancel);
                    if (res == DialogResult.Cancel)
                        Environment.Exit(0);
                }
            } while (windows.Length == 0);

            foreach(var x in windows) { 
                var text = $"{x.Title}, hwnd: {x.Handle:X}";
                //Console.WriteLine(text);
                comboBox1.Items.Add(text);
            }

            comboBox1.SelectedIndex = 0;
            mcWindow = windows[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clickTimer.Enabled = false;
            mcWindow.SendMessage(Window.WM_RBUTTONUP, 0x00000000, 0x1E5025B);
            mcWindow.Maximize();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcWindow = windows[comboBox1.SelectedIndex];
        }
    }
}