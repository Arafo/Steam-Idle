using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace steam_idle_gui
{
    public partial class EditBlacklist : UserControl
    {
        private List<Games> games;
        private Form1 mainForm = null;
        public EditBlacklist(Form callingForm)
        {
            this.mainForm = callingForm as Form1;
            this.InitializeComponent();
        }

        private void AddGameButton_Click(object sender, EventArgs e)
        {
            if (this.GamesComboBox.Items.Count > 0)
            {
                int selectedIndex = this.GamesComboBox.SelectedIndex;
                if (this.BlacklistRichTextBox.Text.Contains(this.games[selectedIndex].ID))
                {
                    this.InfoLabel.Text = this.games[selectedIndex].Game + " is already on blacklist";
                    this.InfoLabel.Visible = true;
                }
                else
                {
                    this.BlacklistRichTextBox.AppendText(this.games[selectedIndex].ID + " || " + this.games[selectedIndex].Game + Environment.NewLine);
                    this.InfoLabel.Text = this.games[selectedIndex].Game + " added to blacklist";
                    this.InfoLabel.Visible = true;
                }
            }
        }

        private void BlacklistRichTextBox_TextChanged(object sender, EventArgs e)
        {
            this.SaveButton.Enabled = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.BlacklistRichTextBox.Clear();
        }

        private void EditBlacklist_Load(object sender, EventArgs e)
        {
            this.WhilelistCheckBox.Checked = steam_idle_gui.Properties.Settings.Default.InvertBlacklist;
            this.InfoLabel.Visible = false;
            this.games = this.mainForm.getListGames();
            if (this.games != null)
            {
                this.games = (from o in this.games
                              orderby o.Game
                              select o).ToList<Games>();
                this.GamesComboBox.DataSource = this.games;
                this.GamesComboBox.DisplayMember = "Game";
                this.GamesComboBox.ValueMember = "Game";
                this.AddGameButton.Enabled = true;
            }
            try
            {
                this.BlacklistRichTextBox.LoadFile("config/blacklist.txt", RichTextBoxStreamType.PlainText);
            }
            catch
            {
            }
            this.SaveButton.Enabled = false;
        }

        private void EditBlacklist_ParentChanged(object sender, EventArgs e)
        {
        }

        private void EditBlacklist_VisibleChanged(object sender, EventArgs e)
        {
            steam_idle_gui.Properties.Settings.Default.InvertBlacklist = this.WhilelistCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.Save();
        }

        private void GetGamesButton_Click(object sender, EventArgs e)
        {
            this.mainForm.UpdateButtonWorker.RunWorkerAsync();
        }

        public bool getInvertBlacklist()
        {
            return this.WhilelistCheckBox.Checked;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            base.ParentForm.FormClosing += new FormClosingEventHandler(this.ParentForm_FormClosing);
        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            steam_idle_gui.Properties.Settings.Default.InvertBlacklist = this.WhilelistCheckBox.Checked;
            steam_idle_gui.Properties.Settings.Default.Save();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.BlacklistRichTextBox.SaveFile("config/blacklist.txt", RichTextBoxStreamType.PlainText);
            this.InfoLabel.Text = "Blacklist saved";
            this.InfoLabel.Visible = true;
            this.SaveButton.Enabled = false;
        }

        public void setGamesComboBox()
        {
            this.games = this.mainForm.getListGames();
            this.GamesComboBox.DataSource = this.games;
            this.GamesComboBox.DisplayMember = "Game";
            this.GamesComboBox.ValueMember = "Game";
            this.AddGameButton.Enabled = true;
        }

    }
}
