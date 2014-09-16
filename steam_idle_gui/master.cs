using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using steam_idle_gui.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using steam_idle_gui;

namespace steam_idle_gui
{
    class master
    {
        private static string uri = "steamcommunity.com";
        private static string sessionid;
        private static string steamLogin;
        private static string steamparental;
        public delegate void ProgressUpdate(string value);
        public event ProgressUpdate WriteOnConsole;
        public delegate void LabelText(string value, Color color);
        public event LabelText setLabelText;
        public delegate bool Sleep(int delay);
        public event Sleep SleepFor;
        public delegate bool CountRows();
        public event CountRows CountRow;
        public delegate void UpdateRows(int drops, string ID);
        public event UpdateRows UpdateRow;
        public delegate void DeleteRows(string ID);
        public event DeleteRows DeleteRow;
        public delegate void GameHeader(string value);
        public event GameHeader setGameHeader;
        public delegate void playSound();
        public event playSound play;


        // Devuelve una lista de 'Games' que contiene todos los juegos que 
        // todavia tienen cartas por obtener
        // Si el parametro 'getName' es 'true' la lista contendra los 
        // nombres de los juegos, ademas de su ID y cartas pendientes
        // Si el parametro 'getName' es 'false' la lista solo contendra
        // la ID y el numero de cartas pendientes
        public List<Games> getGames(bool getName, bool getValue, string mode, bool invertBlacklist)
        {
            int i = 0, y = 0;
            List<Games> games = new List<Games>(); // Lista de juegos que tienen cartas con su ID
            List<string> dropCount = new List<string>(); // Drops restantes
            char[] d = { '/' }; // Delimitador

            HtmlAgilityPack.HtmlDocument doc = getHtmlDoc("/badges/");
            //dropCount = dropCards(doc);

            // Drops restantes de cada juego extraido del codigo HTML
            dropCount = dropCards(doc);
            List<int> blacklist = getBlacklist();

            HtmlNodeCollection n = doc.DocumentNode.SelectNodes("//div[@class='badge_title']");
            if (n == null) return games;
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='badge_row_overlay']"))
            {
                if (!n[y].InnerText.Contains("Foil"))
                {
                    var tmp = node.GetAttributeValue("href", null).ToString().Split(d);
                    if (i < dropCount.Count && dropCount.ElementAt(i) != "No")
                    {
                        string value = "Not found";
                        if (getValue)
                        {
                            using (WebClient client = new WebClient())
                            {
                                value = client.DownloadString("http://api.enhancedsteam.com/market_data/average_card_price/?appid=" 
                                    + tmp[6] + "&cur=eur");
                            }
                        }
                        if (mode == "UPDATE") // Si en las lista 'games' tiene que estar el nombre del juego
                        {
                            var name = Settings.ReadSetting(tmp[6]);
                            if (name.Equals("Not Found"))
                            {
                                var g = getAppName(tmp[6]);
                                games.Add(new Games { 
                                    Game = g, ID = tmp[6], 
                                    Drops = dropCount.ElementAt(i), 
                                    Value = value 
                                });
                                Settings.AddUpdateAppSettings(tmp[6], g);
                            }
                            else
                            {
                                games.Add(new Games { 
                                    Game = name.ToString(), 
                                    ID = tmp[6], Drops = dropCount.ElementAt(i), 
                                    Value = value 
                                });
                            }
                        }
                        else // Sino lista 'games' sin nombre (Auto Mode)
                        {
                            if (invertBlacklist == false)
                            {
                                BlacklistRequest(blacklist, tmp[6], getName, games, dropCount, i, value);
                            }
                            else
                            {
                                WhitelistRequest(blacklist, tmp[6], getName, games, dropCount, i, value);
                            }
                        }
                    }
                    i++; 
                }
                y++;
            }
            return games;
        }

        private void WhitelistRequest(List<int> blacklist, string game, bool getName, 
            List<Games> games, List<string> dropCount, int i, string value)
        {
            if (blacklist.Contains(Convert.ToInt32(game)))
            {

                if (getName) // Si en las lista 'games' tiene que estar el nombre del juego
                {
                    var name = Settings.ReadSetting(game);
                    if (name.Equals("Not Found"))
                    {
                        var g = getAppName(game);
                        games.Add(new Games { 
                            Game = g, ID = game,
                            Drops = dropCount.ElementAt(i), 
                            Value = value 
                        });
                        Settings.AddUpdateAppSettings(game, g);
                    }
                    else
                    {
                        games.Add(new Games { 
                            Game = name.ToString(), 
                            ID = game, Drops = dropCount.ElementAt(i), 
                            Value = value 
                        });
                    }
                }
            }
            else
            {
                if (WriteOnConsole != null)
                {
                    var name = Settings.ReadSetting(game);
                    if (name.Equals("Not Found"))
                        name = getAppName(game);
                    WriteOnConsole(name + steam_idle_gui.Resources.Resources.Blacklist);
                }
            }
        }

        private void BlacklistRequest(List<int> blacklist, string game, bool getName, 
            List<Games> games, List<string> dropCount, int i, string value)
        {
            if (blacklist.Contains(Convert.ToInt32(game)))
            {
                if (WriteOnConsole != null)
                {
                    WriteOnConsole(getAppName(game) + steam_idle_gui.Resources.Resources.Blacklist);
                }
            }
            else
            {
                if (getName) // Si en las lista 'games' tiene que estar el nombre del juego
                {
                    var name = Settings.ReadSetting(game);
                    if (name.Equals("Not Found"))
                    {
                        var g = getAppName(game);
                        games.Add(new Games { 
                            Game = g, ID = game,
                            Drops = dropCount.ElementAt(i), 
                            Value = value 
                        });
                        Settings.AddUpdateAppSettings(game, g);
                    }
                    else
                    {
                        games.Add(new Games { 
                            Game = name.ToString(), ID = game,
                            Drops = dropCount.ElementAt(i),
                            Value = value 
                        });
                    }
                }
                else
                {
                    games.Add(new Games {
                        Game = "", ID = game,
                        Drops = dropCount.ElementAt(i), 
                        Value = value
                    });
                }
            }
        }

        // Devuelve el documento HTML correspondiente a la pagina de insignias
        public HtmlAgilityPack.HtmlDocument getHtmlDoc(String s)
        {
            string htmlCode = ""; // Codigo HTML
            string myURL = "http://steamcommunity.com/profiles/"; // URL a la cuenta de Steam
            try
            {
                 myURL =  myURL + steamLogin.Substring(0, 17);
            }
            catch (ArgumentOutOfRangeException)
            {
                WriteOnConsole(Resources.Resources.steamLoginError);
            }

            // Cliente con las cookies necesarias para obtener la información de las cartas
            CookieAwareWebClient client = generateCookies();
            // String que contiene el codigo HTML de la pagina correspondiente a las cartas
            try
            {
                htmlCode = client.DownloadString(myURL + s);
            }
            catch (System.Net.WebException)
            {
                WriteOnConsole("Conection error");
            }


            // Parser del codigo HTML
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlCode);
            
            return doc;
        }

        // Devuelve un contenedor con las cookies para establecer la
        // conexion a traves de estas
        private CookieAwareWebClient generateCookies()
        {
            CookieContainer cookieJar = new CookieContainer();
            cookieJar.Add(new Cookie("sessionid", sessionid, "/", uri));
            cookieJar.Add(new Cookie("steamLogin", steamLogin, "/", uri));
            cookieJar.Add(new Cookie("steamparental", steamLogin, "/", uri));
            return new CookieAwareWebClient(cookieJar);
        }

        // Devuelve una lista de string con las cartas que quedan
        // Algunos elementos pueden no ser validos. Se comprueban en getGames
        private List<string> dropCards(HtmlAgilityPack.HtmlDocument doc)
        {
            List<string> dropCount = new List<string>(); 
            var nodes = doc.DocumentNode.SelectNodes("//span[@class='progress_info_bold']");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    if (node != null)
                    {
                        dropCount.Add(node.InnerText.Split(' ')[0]);
                    }
                }
            }
            return dropCount;
        }

        // Devuelve el nombre del juego dada su ID
        // Si la ID no esta en el archivo '.config' se busca su nombre en la
        // pagina del dicho juego (Mas costoso)
        public string getAppName(string appID)
        {
            var ID = "";
            try
            {
                var name = Settings.ReadSetting(appID);
                if (name.Equals("Not Found"))
                {
                    WebClient client = new WebClient();
                    string reply = client.DownloadString("http://store.steampowered.com/api/appdetails/?appids=" 
                        + appID + "&filters=basic");
                    JObject o = JObject.Parse(reply);
                    ID = (string)o[appID]["data"]["name"].ToString();
                }
                else
                {
                    ID = name.ToString();
                }
            }
            catch (NullReferenceException)
            {
                return "app " + appID;
            }
            return ID;
        }

        // Devuelve el tiempo de espera entre comprobaciones
        // Si el juego tiene mas de una carta pendiente devuelve '15 minutos'
        // En caso contrario devuelve '5 minutos'
        public int dropDelay(int numDrops) {
            int baseDelay = 0;
            if (numDrops > 1) 
            {
                baseDelay = (15*60);
            } else 
            {
                baseDelay = (5*60);
            }
            return baseDelay;
        }

        // Devuelve una cadena que contiene el header '.jpg' correspondiente a la appID
        public string getAppHeader(string appID)
        {
            return "http://cdn.akamai.steamstatic.com/steam/apps/" + appID + "/header_292x136.jpg";
        }

        // Devuelve la información correspondiente al proceso utilizado para el idling
        public ProcessStartInfo idleOpen(string appID)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = "lib";
            startInfo.FileName = "steam_idle.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = appID;
            return startInfo;
        }

        // Dada una ID devuelve un entero con las cartas pendientes de dicho juego
        public int getDropsAppID(string appID)
        {
            int drops = 1;
            string myURL = "http://steamcommunity.com/profiles/";
            try
            {
                myURL = myURL + steamLogin.Substring(0, 17);
            }
            catch (ArgumentOutOfRangeException)
            {
                WriteOnConsole(Resources.Resources.steamLoginError);
            }
            CookieAwareWebClient client = generateCookies();
            string htmlCode = client.DownloadString(myURL + "/gamecards/" + appID + "/");
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlCode);
            var nodes = doc.DocumentNode.SelectNodes("//span[@class='progress_info_bold']")[0];
            if (nodes != null && nodes.InnerText.Contains("No card drops"))
            {
                drops = 0;
            }
            else
            {
                drops = Convert.ToInt32(nodes.InnerText.Split(' ')[0]);
            }
            return drops;
        }

        // Mata todos los procesos 'steam_idle.exe'
        // MEJORAR PARA QUE SOLO MATA EL PROCESO ADECUADO
        public void idleClose(String appID)
        {
            //if (appID != null) 
                //WriteOnConsole("Closing game " + getAppName(appID)); 
            Process[] proc = Process.GetProcessesByName("steam_idle");
            foreach (Process p in proc)
            {
                try
                {
                    p.Kill();
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    WriteOnConsole("TEST");
                }
            }
        }

        // Leer el archivo 'settings.txt' y rellena las cookies con su contenido
        public string[] getSettings(bool writeInfo)
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines("config/settings.txt");
                sessionid = lines[0].Split('"')[1];
                if (sessionid == "" && writeInfo) WriteOnConsole(Resources.Resources.Nosessionid);
                steamLogin = lines[1].Split('"')[1];
                if (steamLogin == "" && writeInfo) WriteOnConsole(Resources.Resources.NosteamLogin);
                steamparental = lines[2].Split('"')[1];
            }
            catch (Exception)
            {
                //ResultBlock.Text = "Could not read the file";
            }
            return lines;
        }

        private List<int> getBlacklist()
        {
            List<int> blacklist = new List<int>();
            try
            {
                int i = 0;
                string[] lines = System.IO.File.ReadAllLines("config/blacklist.txt");
                foreach (string line in lines)
                {
                    char[] d = { '|' };
                    blacklist.Add(Convert.ToInt32(lines[i].Split(d)[0].Trim()));
                    i++;
                }
                if (blacklist.Count == 0)
                {
                    //Console.WriteLine("No games have been blacklisted");
                }

            }
            catch (Exception)
            {
                //Console.WriteLine("Error blacklist");
            }
            return blacklist;
        }

        public bool chillOut(String appID)
        {
            WriteOnConsole(steam_idle_gui.Resources.Resources.SuspendingGame + getAppName(appID));
            setLabelText(steam_idle_gui.Resources.Resources.NotInGame, Color.FromArgb(86, 163, 204));
            idleClose(appID);
            bool stillDown = true;
            bool cancel = false;
            while (stillDown)
            {
                WriteOnConsole(string.Format(steam_idle_gui.Resources.Resources.SleepingFor, 5));
                cancel = SleepFor(5 * 60);
                if (cancel)
                    break;
                //Thread.Sleep(5 * 60000);
                try
                {
                    HtmlAgilityPack.HtmlDocument rBadge = getHtmlDoc("/gamecards/" + appID + "/");
                    HtmlNodeCollection node = rBadge.DocumentNode.SelectNodes("//span[@class='progress_info_bold']");
                    if (node[0].InnerText.Contains("card drops"))
                    {
                        stillDown = false;
                    }
                }
                catch (Exception)
                {
                    WriteOnConsole(steam_idle_gui.Resources.Resources.NoDrops);
                }
            }
            //idleOpen(appID);
            return cancel;
        }

        public void DropsGames(List<Games> games, BackgroundWorker AutoModeWorker, ProcessStartInfo info)
        {
            foreach (Games g in games)
            {
                int delay = dropDelay(Convert.ToInt32(g.Drops));
                bool stillHaveDrops = true;
                int numCycles = 50;
                int maxFail = 2;
                int oldDrops = Int32.MaxValue;
                bool cancel = false;
                string AppName = getAppName(g.ID);
                AutoModeWorker.RunWorkerAsync(g.ID);
                setLabelText(steam_idle_gui.Resources.Resources.InGame + "\n" + AppName, Color.FromArgb(147, 181, 22));
                WriteOnConsole(string.Format(steam_idle_gui.Resources.Resources.StartingGame, AppName));
                setGameHeader(getAppHeader(g.ID));
                while (stillHaveDrops)
                {
                    try
                    {      
                        WriteOnConsole(string.Format(steam_idle_gui.Resources.Resources.SleepingFor, (delay / 60)));
                        cancel = SleepFor(delay);
                        if (cancel)
                        {
                            WriteOnConsole(steam_idle_gui.Resources.Resources.ClosingGame + AppName);
                            break;
                        }
                        numCycles -= 1;
                        if (numCycles < 1)
                            stillHaveDrops = false;
                        WriteOnConsole(string.Format(steam_idle_gui.Resources.Resources.CheckingDrops, AppName));
                        int drops = getDropsAppID(g.ID);
                        if (drops == 0)
                        {
                            stillHaveDrops = false;
                            WriteOnConsole(steam_idle_gui.Resources.Resources.NoCard);
                        }
                        else
                        {
                            delay = dropDelay(drops);
                            WriteOnConsole(string.Format(steam_idle_gui.Resources.Resources.RemainingDrops, AppName, drops));
                        }
                        if (CountRow() && oldDrops > drops)
                        {
                            if (drops == 0)
                            {
                                DeleteRow(g.ID); // Si no hay mas cartas borrar la fila
                            }
                            else
                            {
                                oldDrops = drops;
                                UpdateRow(drops, g.ID); // Si no actualizar el numero de cartas
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (maxFail > 0)
                        {
                            WriteOnConsole(steam_idle_gui.Resources.Resources.FailError + maxFail);
                            maxFail -= 1;
                        }
                        else
                        {
                            cancel = chillOut(g.ID);
                            maxFail += 1;
                            if (cancel)
                                break;
                            setLabelText(steam_idle_gui.Resources.Resources.InGame + "\n" + AppName, Color.FromArgb(147, 181, 22));
                            AutoModeWorker.RunWorkerAsync(g.ID);
                        }
                    }
                }
                if (cancel)
                    break;
                AutoModeWorker.CancelAsync();
                Thread.Sleep(1000);
                idleClose(null);
                setLabelText(steam_idle_gui.Resources.Resources.NotInGame, Color.FromArgb(86, 163, 204));
                WriteOnConsole(steam_idle_gui.Resources.Resources.SuccessGame + AppName);
                play();
            }
        }

    }

}
