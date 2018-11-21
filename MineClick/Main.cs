using System;
using System.Windows.Forms;

namespace MineClick
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private Window mcWindow;
        private Window[] windows;
        private System.Timers.Timer clickTimer = new System.Timers.Timer();

        private void UpdateProcesses()
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

            comboMinecraftProcess.Invoke((MethodInvoker)(() =>
            {
                comboMinecraftProcess.Items.Clear();
                foreach (var x in windows)
                {
                    var text = $"{x.Title}, hwnd: {x.Handle:X}";
                    //Console.WriteLine(text);
                    comboMinecraftProcess.Items.Add(text);
                }

                if (comboMinecraftProcess.SelectedIndex == -1 || comboMinecraftProcess.SelectedIndex >= windows.Length)
                    comboMinecraftProcess.SelectedIndex = 0;
            }));

            mcWindow = windows[0];
        }

        private void DoMouseDown()
        {
            try
            {
                UpdateProcesses();
                mcWindow.SendMessage(Window.WM_RBUTTONDOWN, 0x00000001, 0x1E5025B);
                mcWindow.Minimize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DoMouseUp()
        {
            try
            {
                UpdateProcesses();
                mcWindow.SendMessage(Window.WM_RBUTTONUP, 0x00000000, 0x1E5025B);
                mcWindow.Maximize();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateProcesses();
            clickTimer.Interval = 20000;
            clickTimer.Elapsed += clickTimer_Elapsed;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {    
            clickTimer.Enabled = true;

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            comboMinecraftProcess.Enabled = false;

            DoMouseDown();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            clickTimer.Enabled = false;
            DoMouseUp();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            comboMinecraftProcess.Enabled = true;
        }

        void clickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DoMouseDown();
        }

        private void comboMinecraftProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcWindow = windows[comboMinecraftProcess.SelectedIndex];
        }
    }
}