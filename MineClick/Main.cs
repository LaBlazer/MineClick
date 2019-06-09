using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace MineClick
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private Window mcWindow;
        private Window[] windows;
        private System.Timers.Timer clickTimer = new System.Timers.Timer();

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateProcesses();
            clickTimer.Interval = 20000;
            clickTimer.Elapsed += clickTimer_Elapsed;
        }

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
                    var text = $"[0x{x.Handle:X}] {x.Title}";
                    //Console.WriteLine(text);
                    comboMinecraftProcess.Items.Add(text);
                }

                if (comboMinecraftProcess.SelectedIndex < 0 || comboMinecraftProcess.SelectedIndex >= windows.Length)
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
                mcWindow.Hide();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Bruh moment", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void DoMouseUp()
        {
            try
            {
                UpdateProcesses();
                mcWindow.SendMessage(Window.WM_RBUTTONUP, 0x00000000, 0x1E5025B);
                mcWindow.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Bruh moment", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void clickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DoMouseDown();
        }

        private void comboMinecraftProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            mcWindow = windows[comboMinecraftProcess.SelectedIndex];
        }

        private void toggleClicker_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleClicker.Checked) // Turn on
            {
                clickTimer.Enabled = true;

                DoMouseDown();

                comboMinecraftProcess.Enabled = false;
            }
            else // Turn off
            {
                clickTimer.Enabled = false;

                DoMouseUp();

                comboMinecraftProcess.Enabled = true;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (toggleClicker.Checked)
                DoMouseUp();
        }
    }
}