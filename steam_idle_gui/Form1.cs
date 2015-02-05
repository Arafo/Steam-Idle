using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace steam_idle_gui
{
    public partial class Form1 : Form
    {
        private BackgroundWorker AutoModeWorker;
        private SoundPlayer simpleSound;
        public bool debug = false;
        private ProcessStartInfo info;
        private KonamiSequence sequence = new KonamiSequence();
        private master t1 = new master();

        // VARIABLES DE OPCIONES
        private string[] settings;
        private List<Games> games;
        EditBlacklist blacklist;
        AutoMode automode;

        public Form1(String[] args)
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            if (args.Length > 0 && args[0].Equals("-d"))
            {
                debug = true;
            }
            t1.WriteOnConsole += OnProgressUpdate;
            t1.setLabelText += LabelText;
            t1.setGameHeader += GameHeader;
            t1.SleepFor += Sleep;
            t1.play += playSound;
            t1.CountRow += CountRows;
            t1.UpdateRow += UpdateRows;
            t1.DeleteRow += DeleteRows;
            t1.onProgressBarUpdate += UpdateButtonWorker_onProgressUpdate;
            t1.updateMaxProgressBar += updateMaxProgressBar;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.SetOut(new TextBoxWriter(textBox1));
            this.settings = this.t1.getSettings(true);
            blacklist = new EditBlacklist(this);
            automode = new AutoMode(this);
            automode.getOrderBox().SelectedIndex = steam_idle_gui.Properties.Settings.Default.OrderIndex; 
            simpleSound = new SoundPlayer(steam_idle_gui.Properties.Resources.message);
            groupBox1.Hide();
            if (debug)
            {
                groupBox1.Show();
                this.Text = this.Text + " - DEBUG MODE";
            }
            dataGridView1.Columns[3].Visible = false;
            AutoModeWorker = new BackgroundWorker();
            AutoModeWorker.WorkerSupportsCancellation = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoModeWorker.CancelAsync();
            t1.idleClose(null);
            if (automode.getLogCheckBox() && textBox1.Text != null)
            {
                string date = DateTime.Now.ToString("hh-mm-ss-ddd_dd_MMM_yyyy");
                using (StreamWriter w = File.AppendText("logs/" + date + ".log"))
                {
                    string time = DateTime.Now.ToString("dddd MMMM dd hh:mm:ss yyyy");
                    w.WriteLine("===== " + time + " =====");
                    w.WriteLine("===== start =====");
                    w.WriteLine("-------------------------------" + Environment.NewLine);
                    w.WriteLine(textBox1.Text);
                    w.WriteLine("-------------------------------");
                    w.WriteLine("===== end =====");
                }
            }
        }

        /////////////////////////////////////////////////////////////////
        // BUTTONS
        /////////////////////////////////////////////////////////////////

        // Acción asociada al botón 'Start'
        // Si el dataGrid esta vacio o el proceso AutoModeWorker esta ocupado no se realiza ninguna acción
        // En caso contrario se inicia el juego seleccionado en el dataGrid
        private void Start_Click(object sender, EventArgs e)
        {
            if (AutoGamesWorker.IsBusy) // Auto Mode en ejecución
            {
                Console.WriteLine("Proceso Auto ocupado");
            }
            else
            {
                if (dataGridView1.RowCount != 0) // Comprobar si hay elementos en el dataGrid
                {
                    try
                    {
                        var id = dataGridView1[1, dataGridView1.CurrentRow.Index].Value; // appID
                        var drops = dataGridView1[2, dataGridView1.CurrentRow.Index].Value; // Drops
                        var name = dataGridView1[0, dataGridView1.CurrentRow.Index].Value; 
                        List<Games> game = new List<Games>();
                        game.Add(new Games { Game = name.ToString(), ID = id.ToString(), Drops = drops.ToString() });
                        //DropsGames(game);

                        List<Object> arguments = new List<Object>();
                        arguments.Add(false);
                        arguments.Add(game);
                        AutoGamesWorker.RunWorkerAsync(arguments);
                        //Steam.Init(id.ToString());
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Proceso ocupado");
                    }
                }
                else
                {
                    Console.WriteLine(steam_idle_gui.Resources.Resources.NoGameSelect);
                }
            }
        }

        // Acción asociada al botón 'Update'
        // Inicia al worker 'UpdateButtonWorker' para que obtenga los juegos que tienen drops
        // Al ser un proceso largo se ha envuelto en un worker para no parar la interfaz gráfica
        private void Update_Click(object sender, EventArgs e)
        {
            if (!UpdateButtonWorker.IsBusy)
            {
                Console.WriteLine(steam_idle_gui.Resources.Resources.Finding);
                UpdateButtonWorker_onProgressUpdate(0);
                toolStripStatusLabel1.Text = string.Format(steam_idle_gui.Resources.Resources.SearchGames, 0);
                UpdateButtonWorker.RunWorkerAsync();
            }
        }

        // Acción asociada al botón 'Stop'
        // Mata al proceso 'steam_idle' encargado de ejecutar el juego
        // Funciona tanto en modo 'Start' como en modo 'Auto'
        private void Stop_Click(object sender, EventArgs e)
        {
            if (info != null)
            {
                AutoModeWorker.CancelAsync();
                AutoGamesWorker.CancelAsync();
                t1.idleClose(info.Arguments);
                //Steam.Shutdown();
                StateLabel.ForeColor = Color.FromArgb(114, 181, 214);
                StateLabel.Text = "Not In-Game";
                GameHeaderBox.Image = steam_idle_gui.Properties.Resources._default;
            }
        }

        private void AutoModeButton_Click(object sender, EventArgs e)
        {
            if (!AutoGamesWorker.IsBusy)
            {
                Console.WriteLine(steam_idle_gui.Resources.Resources.AutoMode);
                UpdateButtonWorker_onProgressUpdate(0);
                toolStripStatusLabel1.Text = string.Format(steam_idle_gui.Resources.Resources.SearchGames, 0);
                ComboBox Order = automode.getOrderBox();
                bool getValue = Order.SelectedIndex == 3 || Order.SelectedIndex == 5;
                bool getName = Order.SelectedIndex == 0 || Order.SelectedIndex == 1;
                List<Object> arguments = new List<Object>();
                arguments.Add(true);
                arguments.Add(getName);
                arguments.Add(getValue);
                try
                {
                    AutoGamesWorker.RunWorkerAsync(arguments);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Proceso ocupado");
                }
            }
            else
            {
                Console.WriteLine("Proceso ocupado");
            }
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<Options>().Any())
            {
                Options frm = new Options(this);
                frm.Show();
            }

        }

        private void EditSettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("config/settings.txt");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.WriteLine(steam_idle_gui.Resources.Resources.SettingsNotFound);

            }

        }

        private void EditBlacklistButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("config/blacklist.txt");
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.WriteLine(steam_idle_gui.Resources.Resources.BlacklistNotFound);

            }
        }

        /////////////////////////////////////////////////////////////////
        // DATAGRIDVIEW
        /////////////////////////////////////////////////////////////////

        // NO UTILIZADO
        // Acción asociada al hacer click en una fila del dataGrid
        // Si hay juegos cargados en el dataGrid, cada vez que se selecciona uno de ellos
        // se carga en 'GameHeaderBox' el header correspondiente a dicho juego
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.RowCount)
            {
                //Console.WriteLine(dataGridView1[0, e.RowIndex].Value);
                //GameHeaderBox.Load(t1.getAppHeader((string)dataGridView1[1, e.RowIndex].Value));
            }

        }

        // Acción asociada al hacer click a la cabezera del dataGrid
        // Permite alternar el orden en funcion de las colunmas tanto ascendente como descendente
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SortOrder.ToString() == "Descending") 
            {
                dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Descending);
            }
            else
            {
                dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Ascending);
            }
        }

        // NO UTILIZADO
        private void UpdateDropsRow(int drops, String appID)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var r = dataGridView1[1, i].Value;
                if (r.Equals(appID))
                {
                    dataGridView1[2, i].Value = drops;
                    break;
                }
            }
        }

        // NO UTILIZADO
        private void DeleteDropsRow(string appID)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var r = dataGridView1[1, i].Value;
                if (r.Equals(appID))
                {
                    dataGridView1.Rows.RemoveAt(i);
                    break;
                }
            }
        }

        /////////////////////////////////////////////////////////////////
        // BACKGROUNDWORKERS
        /////////////////////////////////////////////////////////////////

        private void UpdateButtonWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            checkSettings();
            e.Result = t1.getGames(true, automode.getValueCheckBox(), "UPDATE", false);
            games = (List<Games>)e.Result;
        }

        private void UpdateButtonWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Games> n = (List<Games>)e.Result;
            if (n != null && n.Count > 0)
            {
                n = n.OrderBy(o => o.Game).ToList();
                BindingListView<Games> view = new BindingListView<Games>(n);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = view;
                dataGridView1.Columns[3].Visible = automode.getValueCheckBox() ? true : false;
                if (dataGridView1.Columns.Count > 0)
                {
                    DataGridViewColumn column = dataGridView1.Columns[0];
                    column.Width = 100;
                    DataGridViewColumn column1 = dataGridView1.Columns[1];
                    column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DataGridViewColumn column2 = dataGridView1.Columns[2];
                    column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    DataGridViewColumn column3 = dataGridView1.Columns[3];
                    column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    if (blacklist != null)
                        blacklist.setGamesComboBox();
                }
                //if (dataGridView1.RowCount > 0)
                    //GameHeaderBox.Load(t1.getAppHeader((string)dataGridView1[1, dataGridView1.CurrentRow.Index].Value));
            }
            Console.WriteLine(n.Count + steam_idle_gui.Resources.Resources.GamesFound);
        }

        private void IdleGameWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            info = t1.idleOpen((string)e.Argument);
            if (automode.getHideCheckBox())
            {
                info.WindowStyle = ProcessWindowStyle.Hidden;
            }
            Process process = Process.Start(info);

            while (!process.HasExited)
            {
                if (AutoModeWorker.CancellationPending)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (System.ComponentModel.Win32Exception) {}

                    continue;
                }
                else
                    Thread.Sleep(1000);
            }
        }

        private void AutoGamesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Object> arguments = (List<Object>)e.Argument;
            AutoModeWorker.DoWork += IdleGameWorker_DoWork;
            AutoModeWorker.WorkerSupportsCancellation = true;
            checkSettings();
            if ((bool)arguments[0]) // Auto Mode
            {
                List<Games> autoGames = t1.getGames((bool)arguments[1], (bool)arguments[2], "AUTO", automode.getInvertBlacklist());
                autoGames = OrderOption(autoGames);
                OnProgressUpdate(string.Format(steam_idle_gui.Resources.Resources.CountGamesAuto, autoGames.Count));
                t1.DropsGames(autoGames, AutoModeWorker, info);
            }
            else // Start Mode
            {
                List<Games> game = (List<Games>)arguments[1];
                OnProgressUpdate(steam_idle_gui.Resources.Resources.CountGamesStart + game[0].Game);
                t1.DropsGames(game, AutoModeWorker, info);
            }

            //e.Result = autoGames;
        }

        private void KWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                Process.Start("http://gabegaming.com/");
            }
        }

        /////////////////////////////////////////////////////////////////
        // ICONO NOTIFICACION
        /////////////////////////////////////////////////////////////////

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState && automode.getMinimizeCheckBox())
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /////////////////////////////////////////////////////////////////
        // OTROS
        /////////////////////////////////////////////////////////////////

        // NO UTILIZADO
        private void DropsGames(List<Games> games)
        {
            foreach (Games g in games)
            {
                int delay = t1.dropDelay(Convert.ToInt32(g.Drops));
                bool stillHaveDrops = true;
                int numCycles = 50;
                int maxFail = 2;
                int oldDrops = Int32.MaxValue;
                bool cancel = false;
                //AutoModeWorker = new BackgroundWorker();
                //AutoModeWorker.DoWork += IdleGameWorker_DoWork;
                //AutoModeWorker.RunWorkerCompleted += IdleGameWorker_RunWorkerCompleted;
                //AutoModeWorker.WorkerSupportsCancellation = true;
                AutoModeWorker.RunWorkerAsync(g.ID);
                LabelText("You're Now In-Game\n" + t1.getAppName((string)g.ID), Color.FromArgb(147, 181, 22));
                GameHeader(t1.getAppHeader(g.ID));
                while (stillHaveDrops)
                {
                    try
                    {
                        //Console.WriteLine(t1.getAppName(g.ID) + " has " + g.Drops + " card drops remaining");
                        OnProgressUpdate("Sleeping for " + (delay / 60) + " minutes");
                        //Thread.Sleep(delay);
                        cancel = Sleep(delay);
                        if (cancel)
                        {
                            OnProgressUpdate("Closing game " + t1.getAppName(info.Arguments)); 
                            break;
                        }
                        numCycles -= 1;
                        if (numCycles < 1)
                            stillHaveDrops = false;
                        int drops = t1.getDropsAppID(g.ID);
                        if (drops == 0)
                        {
                            stillHaveDrops = false;
                            OnProgressUpdate("No card drops remaining");
                        }
                        else
                        {
                            delay = t1.dropDelay(drops);
                            OnProgressUpdate(t1.getAppName(g.ID) + " has " + drops + " card drops remaining");
                        }
                        if (CountRows() && oldDrops > drops)
                        {
                            if (drops == 0)
                            {
                                DeleteRows(g.ID); // Si no hay mas cartas borrar la fila
                            }
                            else
                            {
                                oldDrops = drops;
                                UpdateRows(drops, g.ID); // Si no actualizar el numero de cartas
                            }
                        }
                        OnProgressUpdate("Checking to see if " + t1.getAppName(g.ID) + " has remaining card drops");
                    }
                    catch (Exception)
                    {
                        if (maxFail > 0)
                        {
                            OnProgressUpdate("Error checking if drops are done, number of tries remaining: " + maxFail);
                            maxFail -= 1;
                        }
                        else
                        {
                            cancel = t1.chillOut(g.ID);
                            maxFail += 1;
                            //break;
                        }
                    }
                }
                if (cancel)
                    break;
                AutoModeWorker.CancelAsync();
                Thread.Sleep(1000);
                //t1.idleCose();
                LabelText("Not In-Game", Color.FromArgb(86, 163, 204));
                OnProgressUpdate("Successfully completed idling cards for " + t1.getAppName(g.ID));
                playSound();
            }
        }

        private List<Games> OrderOption(List<Games> games)
        {
            ComboBox OrderBox = automode.getOrderBox();
            base.Invoke((Action)delegate
            {
                if (OrderBox.SelectedItem != null && OrderBox.SelectedIndex == 2) // Less Drops
                {
                    games = games.OrderBy(o => o.Drops).ToList();
                }
                else if (OrderBox.SelectedItem != null && OrderBox.SelectedIndex == 4) // More Drops
                {
                    games = games.OrderByDescending(o => o.Drops).ToList();
                }
                else if (OrderBox.SelectedItem != null && OrderBox.SelectedIndex == 5) // More Value
                {
                    games = games.OrderByDescending(o => o.Value).ToList();
                }
                else if (OrderBox.SelectedItem != null && OrderBox.SelectedIndex == 3) // Less Value
                {
                    games = games.OrderBy(o => o.Value).ToList();
                }
                else if (OrderBox.SelectedItem != null && OrderBox.SelectedIndex == 1) // Descending
                {
                    games = games.OrderByDescending(o => o.Game).ToList();
                }
                else // Ascending
                {
                    games = games.OrderBy(o => o.Game).ToList();
                }
            });
            return games;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (sequence.IsCompletedBy(e.KeyCode))
            {
                this.Text = this.Text + " - GOD MODE";
                KWorker.RunWorkerAsync();
            }
        }

        public string[] getSettings()
        {
            settings = t1.getSettings(false);
            return settings;
        }

        public List<Games> getListGames()
        {
            return this.games;
        }

        public EditBlacklist getEditBlacklist()
        {
            blacklist = new EditBlacklist(this);
            return blacklist;
        }

        public AutoMode getAutoMode()
        {
            automode = new AutoMode(this);
            return automode;
        }

        public ProcessStartInfo getInfo()
        {
            return info;
        }

        private void checkSettings()
        {
            //string sid = settings[0].Split(new char[] { '"' })[1];
            //string slogin = settings[1].Split(new char[] { '"' })[1];
            //if (sid == "" || slogin == "")
                this.settings = t1.getSettings(true);
        }

        /////////////////////////////////////////////////////////////////
        // INTERACTUAR CON LA UI DESDE UN BACKGROUNDWORKER
        /////////////////////////////////////////////////////////////////

        // Escribir en la consola
        private void OnProgressUpdate(string value)
        {
            base.Invoke((Action)delegate
            {
                Console.WriteLine(value);
            });
        }

        // Cambiar el texto del Label de estado
        private void LabelText(string value, Color color)
        {
            base.Invoke((Action)delegate
            {
                StateLabel.ForeColor = color;
                StateLabel.Text = value;
            });
        }

        // Cambiar el header
        private void GameHeader(string value)
        {
            GameHeaderBox.Invoke((MethodInvoker)delegate
            {
                GameHeaderBox.Load(value);
            });
        }

        // Actualizar las filas del datagridview
        private void UpdateRows(int drops, string ID)
        {
            dataGridView1.Invoke((MethodInvoker)delegate
            {
                UpdateDropsRow(drops, ID);
            });
        }

        // Borrar las filas del datagridview
        private void DeleteRows(string ID)
        {
            dataGridView1.Invoke((MethodInvoker)delegate
            {
                DeleteDropsRow(ID);
            });
        }

        // Contar las filas del datagridview
        private bool CountRows()
        {
            bool count = false;
            dataGridView1.Invoke((MethodInvoker)delegate
            {
                count = dataGridView1.RowCount != 0 ? true : false;
            });
            return count;
        }

        // Reproducir el sonido de juego terminado
        private void playSound()
        {
            base.Invoke((MethodInvoker)delegate
            {
                if (automode.getSoundCheckBox().Checked)
                {
                    simpleSound.Play();
                }
            });
        }

        // Dormir bgw delay segundos
        private bool Sleep(int delay)
        {
            bool Cancel = false;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.Elapsed < TimeSpan.FromSeconds(delay))
            {
                if (AutoGamesWorker.CancellationPending)
                {
                    Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
            return Cancel;
        }

        private void UpdateButtonWorker_onProgressUpdate(int value)
        {
            base.Invoke((Action)delegate
            {
                if (toolStripProgressBar1.Maximum >= value)
                    {
                        toolStripProgressBar1.Value = value;
                        toolStripStatusLabel1.Visible = true;
                        double completado = Math.Ceiling(((double)value / (double)toolStripProgressBar1.Maximum) * 100);
                        toolStripStatusLabel1.Text = string.Format(steam_idle_gui.Resources.Resources.SearchGames, completado);
                    }
            });
        }

        private void updateMaxProgressBar(int max, bool decrementarMax)
        {

            base.Invoke((MethodInvoker)delegate
            {
                if (decrementarMax)
                {
                    toolStripProgressBar1.Maximum -= 1;
                } else {
                    toolStripProgressBar1.Maximum = max;
                }
            });
        }
    }
}
