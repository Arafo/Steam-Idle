using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace steam_idle_gui
{
    public partial class EditSettings : UserControl
    {
        private Form1 mainForm = null;
        public EditSettings(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }
        private void EditSettings_Load(object sender, EventArgs e)
        {
            string[] strArray = this.mainForm.getSettings();
            this.textBox1.Text = strArray[0].Split(new char[] { '"' })[1];
            this.textBox2.Text = strArray[1].Split(new char[] { '"' })[1];
            this.textBox3.Text = strArray[2].Split(new char[] { '"' })[1];
            this.SaveButton.Enabled = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            File.WriteAllText("config/settings.txt", "sessionid = \"" + this.textBox3.Text + "\"" + Environment.NewLine + "steamLogin = \"" + this.textBox1.Text + "\"" + Environment.NewLine + "steamparental = \"" + this.textBox2.Text + "\"\n");
            this.SaveButton.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.SaveButton.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.SaveButton.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.SaveButton.Enabled = true;
        }
    }
}
