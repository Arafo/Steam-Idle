using System;
using System.Windows.Forms;

namespace steam_idle_gui
{
    public partial class AutoMode : UserControl
    {
        private Form1 mainForm = null;
        public AutoMode(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            LoadSettings();
        }

        private void AutoMode_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            this.OrderBox.SelectedIndex = steam_idle_gui.Properties.Settings.Default.OrderIndex;
            this.ValueCheckBox.Checked = steam_idle_gui.Properties.Settings.Default.ValueCheck;
            this.HideCheckBox.Checked = steam_idle_gui.Properties.Settings.Default.HideCheck;
            this.SoundCheckBox.Checked = steam_idle_gui.Properties.Settings.Default.SoundCheck;
            this.MinimizeCheckBox.Checked = steam_idle_gui.Properties.Settings.Default.MinimizeCheck;
            this.LogCheckBox.Checked = steam_idle_gui.Properties.Settings.Default.LogCheck;
        }

        private void AutoMode_VisibleChanged(object sender, EventArgs e)
        {
            steam_idle_gui.Properties.Settings.Default.OrderIndex = this.OrderBox.SelectedIndex;
            steam_idle_gui.Properties.Settings.Default.ValueCheck = this.ValueCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.HideCheck = this.HideCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.SoundCheck = this.SoundCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.MinimizeCheck = this.MinimizeCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.LogCheck = this.LogCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.Save();
        }

        public bool getHideCheckBox()
        {
            return this.HideCheckBox.Checked;
        }

        public bool getMinimizeCheckBox()
        {
            return this.MinimizeCheckBox.Checked;
        }

        public ComboBox getOrderBox()
        {
            return this.OrderBox;
        }

        public CheckBox getSoundCheckBox()
        {
            return this.SoundCheckBox;
        }

        public bool getValueCheckBox()
        {
            return this.ValueCheckBox.Checked;
        }

        public bool getLogCheckBox()
        {
            return LogCheckBox.Checked;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            base.ParentForm.FormClosing += new FormClosingEventHandler(this.ParentForm_FormClosing);
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            steam_idle_gui.Properties.Settings.Default.OrderIndex = this.OrderBox.SelectedIndex;
            steam_idle_gui.Properties.Settings.Default.ValueCheck = this.ValueCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.HideCheck = this.HideCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.SoundCheck = this.SoundCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.MinimizeCheck = this.MinimizeCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.LogCheck = this.LogCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.Save();
        }
    }
}
