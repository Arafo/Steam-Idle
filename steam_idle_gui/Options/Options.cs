using System;
using System.Windows.Forms;

namespace steam_idle_gui
{
    public partial class Options : Form
    {
        private Form1 mainForm = null;
        public Options(Form callingForm)
        {
            mainForm = callingForm as Form1; 
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            if (!mainForm.debug)
                treeView1.Nodes[3].Remove();
            this.treeView1.SelectedNode = treeView1.Nodes[steam_idle_gui.Properties.Settings.Default.TreeIndex];
            if (steam_idle_gui.Properties.Settings.Default.WindowLocation != null)
            {
                this.Location = steam_idle_gui.Properties.Settings.Default.WindowLocation;
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Name == "Options")
            {
                panel.Controls.Clear();
                panel.Visible = false;
            }
            if (treeView1.SelectedNode.Name == "AutoMode")
            {
                panel.Controls.Clear();
                panel.Visible = true;
                AutoMode usr2 = this.mainForm.getAutoMode();
                usr2.Show();
                panel.Controls.Add(usr2);
            }
            if (treeView1.SelectedNode.Name == "EditSettings")
            {
                panel.Controls.Clear();
                panel.Visible = true;
                EditSettings usr1 = new EditSettings(mainForm);
                usr1.Show();
                panel.Controls.Add(usr1);
            }
            if (treeView1.SelectedNode.Name == "EditBlacklist")
            {
                panel.Controls.Clear();
                panel.Visible = true;
                EditBlacklist usr1 = this.mainForm.getEditBlacklist();
                usr1.Show();
                panel.Controls.Add(usr1);
            }
            if (treeView1.SelectedNode.Name == "Cards")
            {
                panel.Controls.Clear();
                panel.Visible = true;
                Cards usr1 = new Cards(mainForm);
                usr1.Show();
                panel.Controls.Add(usr1);
            }
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            steam_idle_gui.Properties.Settings.Default.TreeIndex = treeView1.SelectedNode.Index;
            steam_idle_gui.Properties.Settings.Default.WindowLocation = this.Location;
            steam_idle_gui.Properties.Settings.Default.Save();
        }
    }
}
