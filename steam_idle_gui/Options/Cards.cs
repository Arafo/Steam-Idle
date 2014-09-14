using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace steam_idle_gui
{
    public partial class Cards : UserControl
    {
        private string ID;
        private master m = new master();
        private Form1 mainForm = null;
        public Cards(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void Cards_Load(object sender, EventArgs e)
        {
            string[] settings = this.mainForm.getSettings();
            ID = settings[1].Substring(14, 17);
        }

        private void GetCardsButton_Click(object sender, EventArgs e)
        {
            if (!CardsBackgroundWorker.IsBusy)
            {
                CardsBackgroundWorker.RunWorkerAsync();
            }
        }

        private void CardsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Card> card = new List<Card>();
            string inventory = getInventoryJson();
            dynamic cards = JsonConvert.DeserializeObject(inventory);
            foreach (var child in cards.rgInventory.Children())
            {
                foreach (var desc in cards.rgDescriptions.Children())
                {
                    var i = child.First.classid;
                    var j = desc.First.classid;
                    string type = desc.First.type;
                    string market = desc.First.market_name;
                    string appID = desc.First.market_fee_app;
                    if (i == j && type.Contains("Card") && !contains(card, market))
                    {
                        string value = "";// getCardValue(market);
                        card.Add(new Card
                        {  //classid = desc.First.classid,
                            // name = desc.First.name,
                            game = m.getAppName(appID),
                            market_name = market,
                            value = value
                        });
                    }
                }
                //var j = cards.rgDescriptions.Children();
                //string i = "Item ID: {0}" + child.First.classid;
            }
            e.Result = card;
        }

        private string getInventoryJson()
        {
            string JsonCode = "";
            string myURL = "http://steamcommunity.com/profiles/" + ID;
            try
            {
                JsonCode = new WebClient().DownloadString(myURL + "/inventory/json/753/6");
            }
            catch (System.Net.WebException)
            {
                //WriteOnConsole("Conection error");
            }
            return JsonCode;
        }

        private void CardsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Card> cards = (List<Card>)e.Result;
            CardsDataGridView.DataSource = cards;
        }

        private bool contains(List<Card> g, string s)
        {
            bool contain = false;
            for (int i = 0; i < g.Count; i++)
            {
                if (g[i].market_name == s)
                {
                    contain = true;
                    break;
                }
            }
            return contain;
        }

        private string getCardValue(string id)
        {
            string value = "";
            string JsonCode = "";
            string myURL = "http://steamcommunity.com/market/search/render/?query=";
            try
            {
                JsonCode = new WebClient().DownloadString(myURL + id);
            }
            catch (System.Net.WebException) { }
            var results = JsonConvert.DeserializeObject(JsonCode);
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //foreach (var child in results.Children())
            //{
            //var test = child.First;
            //}
            //var v = Regex.Match(JsonCode, "market_listing_item_name\".*?>.*?<");
            var prices = Regex.Match(JsonCode, "&#36;([0-9]+.[0-9]+)");
            // string s = v.Groups[1].ToString();
            string p = prices.Groups[1].ToString();

            //doc.LoadHtml(HtmlCode);
            //HtmlNode n = doc.DocumentNode.SelectSingleNode("//span[@style='color:white']");
            //if (n != null)
            //    value = n.InnerText.Substring(5,8);
            return p;
        }

        public uint NumSlots { get; set; }
        public Item[] Items { get; set; }
        public bool IsPrivate { get; private set; }
        public bool IsGood { get; private set; }
        
        //protected Inventory (InventoryResult apiInventory) {
          //  NumSlots = apiInventory.num_backpack_slots;
          //  Items = apiInventory.items;
          //  IsPrivate = (apiInventory.status == "15");
         //   IsGood = (apiInventory.status == "1");
        //}
        
        public class Item {
            public int AppId = 753;
            public long ContextId = 6;
            
            [JsonProperty("id")]
            public ulong Id { get; set; }
            [JsonProperty("original_id")]
            public ulong OriginalId { get; set; }
            [JsonProperty("defindex")]
            public ushort Defindex { get; set; }
            [JsonProperty("level")]
            public byte Level { get; set; }
            [JsonProperty("quality")]
            public string Quality { get; set; }
            [JsonProperty("quantity")]
            public int RemainingUses { get; set; }
            [JsonProperty("origin")]
            public int Origin { get; set; }
            [JsonProperty("custom_name")]
            public string CustomName { get; set; }
            [JsonProperty("custom_desc")]
            public string CustomDescription { get; set; }
            [JsonProperty("flag_cannot_craft")]
            public bool IsNotCraftable { get; set; }
            [JsonProperty("flag_cannot_trade")]
            public bool IsNotTradeable { get; set; }
            [JsonProperty("attributes")]
            public ItemAttribute[] Attributes { get; set; }
            [JsonProperty("contained_item")]
            public Item ContainedItem { get; set; }
        }
        
        public class ItemAttribute
        {
            [JsonProperty("defindex")]
            public ushort Defindex { get; set; }
            [JsonProperty("value")]
            public string Value { get; set; }
            [JsonProperty("float_value")]
            public float FloatValue { get; set; }
            [JsonProperty("account_info")]
            public AccountInfo AccountInfo { get; set; }
        }

        public class AccountInfo
        {
            [JsonProperty("steamid")]
            public ulong SteamID { get; set; }
            [JsonProperty("personaname")]
            public string PersonaName { get; set; }
        }
        
        protected class InventoryResult
        {
            public string status { get; set; }
            public uint num_backpack_slots { get; set; }
            public Item[] items { get; set; }
        }
        
        protected class InventoryResponse
        {
            public InventoryResult result;
        }

        private void CardsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < CardsDataGridView.RowCount)
            {
                //PictureBox cardImage = new PictureBox();
                string icon_url = "IzMF03bi9WpSBq-S-ekoE33L-iLqGFHVaU25ZzQNQcXdA3g5gMEPvUZZEaiHLrVJRsl8qnWEU47Cjc9ehDNVzDMEfXKohCQrcex4NM6b7jXLhaSEEXXwbWqVKySLTwg7GLQMNG3f-Df2trmUEDHISOAoQ1gGK6IM-2ZNbpiBbUE-ysdVrCO6mFZ5GwQXe8hHdwrmzyZFaO8kzndGJMpQzyDyJ53ejVthO0Q5XOvuU-rFaomilCYsW05lFr5aOtyD_ijtzwU7xak";
                //cardImage.Location = MousePosition;
                CardPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                CardPictureBox.Load("http://steamcommunity-a.akamaihd.net/economy/image/" + icon_url);
                //Console.WriteLine(dataGridView1[0, e.RowIndex].Value);
                //GameHeaderBox.Load(t1.getAppHeader((string)dataGridView1[1, e.RowIndex].Value));
            }
        }
    }
}
