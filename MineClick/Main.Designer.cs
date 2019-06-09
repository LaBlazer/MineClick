namespace MineClick
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.comboMinecraftProcess = new MetroFramework.Controls.MetroComboBox();
            this.toolTip = new MetroFramework.Components.MetroToolTip();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.toggleClicker = new MetroFramework.Controls.MetroToggle();
            this.labelHelp = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // comboMinecraftProcess
            // 
            this.comboMinecraftProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMinecraftProcess.FormattingEnabled = true;
            this.comboMinecraftProcess.ItemHeight = 23;
            this.comboMinecraftProcess.Location = new System.Drawing.Point(23, 63);
            this.comboMinecraftProcess.Name = "comboMinecraftProcess";
            this.comboMinecraftProcess.Size = new System.Drawing.Size(285, 29);
            this.comboMinecraftProcess.TabIndex = 6;
            this.toolTip.SetToolTip(this.comboMinecraftProcess, "Select the correct Minecraft process");
            this.comboMinecraftProcess.SelectedIndexChanged += new System.EventHandler(this.comboMinecraftProcess_SelectedIndexChanged);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 350;
            this.toolTip.ReshowDelay = 100;
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Style = MetroFramework.MetroColorStyle.Green;
            this.styleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // toggleClicker
            // 
            this.toggleClicker.AutoSize = true;
            this.toggleClicker.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.toggleClicker.Location = new System.Drawing.Point(228, 98);
            this.toggleClicker.Name = "toggleClicker";
            this.toggleClicker.Size = new System.Drawing.Size(80, 19);
            this.toggleClicker.TabIndex = 7;
            this.toggleClicker.Text = "Off";
            this.toolTip.SetToolTip(this.toggleClicker, "Turn on the autoclicker");
            this.toggleClicker.UseVisualStyleBackColor = true;
            this.toggleClicker.CheckedChanged += new System.EventHandler(this.toggleClicker_CheckedChanged);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelHelp.Location = new System.Drawing.Point(23, 98);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(80, 19);
            this.labelHelp.TabIndex = 8;
            this.labelHelp.Text = "How to run?";
            this.toolTip.SetToolTip(this.labelHelp, resources.GetString("labelHelp.ToolTip"));
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 137);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.toggleClicker);
            this.Controls.Add(this.comboMinecraftProcess);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Resizable = false;
            this.Text = "MineClick by LBLZR_";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox comboMinecraftProcess;
        private MetroFramework.Components.MetroToolTip toolTip;
        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroToggle toggleClicker;
        private MetroFramework.Controls.MetroLabel labelHelp;
    }
}

