using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace steam_idle_gui
{
    public partial class EditBlacklist : UserControl
    {
        private List<Games> games;
        private Form1 mainForm = null;
        private Dictionary<string, string> VACGames;
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

        private void GetGamesButton_Click(object sender, EventArgs e)
        {
            this.mainForm.UpdateButtonWorker.RunWorkerAsync();
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

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            this.VACButton.Enabled = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int pagina = 1;
            int maxPagina = 0;
            String uri = "http://store.steampowered.com/search/?category1=998&category2=8&page=";
            VACGames = new Dictionary<string, string>();

            HtmlAgilityPack.HtmlDocument doc = htmlPage(uri + pagina);
            try
            {
                HtmlNode pag = doc.DocumentNode.SelectSingleNode("//div[@class='search_pagination_left']");
                string[] lines = Regex.Split(pag.InnerText, " ");
                int gamesPerPag = Convert.ToInt32(lines[3]);
                int totalGames = Convert.ToInt32(lines[5]);
                maxPagina = (totalGames + gamesPerPag - 1) / gamesPerPag;

                updateMaxProgressBar(totalGames);

                for (pagina = 1; pagina <= maxPagina; pagina++)
                {
                    if (pagina != 1)
                    {
                        doc = htmlPage(uri + pagina);
                    }
                    // Obtener juegos con cromos y VAC
                    getVACGames(doc, pagina, gamesPerPag);
                }
            }
            catch (NullReferenceException) { }
            e.Result = VACGames;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            //this.Text = e.ProgressPercentage.ToString();
        }

        private void getVACGames(HtmlAgilityPack.HtmlDocument doc, int pagina, int gamesPerPag)
        {
            int i = (pagina - 1)*gamesPerPag;
            foreach (HtmlNode pag in doc.DocumentNode.SelectNodes("//div[@class='col search_capsule']"))
            {
                string[] stringSeparators = new string[] { "/", "Buy", "\" width=" };
                string[] lines = pag.InnerHtml.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                String steamAppID = lines[4];
                String steamAppTitle = lines[6];
                try
                {
                    VACGames.Add(steamAppID, steamAppTitle);
                    i += 1;
                }
                catch (ArgumentException) { }
                backgroundWorker1.ReportProgress(i);
            }
        }

        private HtmlAgilityPack.HtmlDocument htmlPage(String uri) 
        {
            String htmlCode = null;
            using (WebClient client = new WebClient ())
            {
                 htmlCode = client.DownloadString(uri);        
            }
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlCode);
            return doc;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int addedGames = 0;
            Dictionary<string, string> n = (Dictionary<string, string>)e.Result;
            foreach (KeyValuePair<string, string> entry in n) 
            {
                if (!this.BlacklistRichTextBox.Text.Contains(entry.Key))
                {
                    this.BlacklistRichTextBox.AppendText(entry.Key + " ||" + entry.Value + Environment.NewLine);
                    addedGames++;
                }
            }
            this.BlacklistRichTextBox.Text.TrimStart('\r', '\n');
            this.InfoLabel.Visible = true;
            // MOVER EL STRING A RESOURCES
            if (addedGames == 1)
            {
                this.InfoLabel.Text = addedGames + " game added to blacklist";
            }
            else
            {
                this.InfoLabel.Text = addedGames + " games added to blacklist";
            }
            this.VACButton.Enabled = true;
        }
        private void updateMaxProgressBar(int max)
        {

            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Maximum = max;
            });
        }
    }
}
