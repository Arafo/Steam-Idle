namespace steam_idle_gui
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.UpdateButtonWorker = new System.ComponentModel.BackgroundWorker();
            this.AutoGamesWorker = new System.ComponentModel.BackgroundWorker();
            this.KWorker = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.AutoModeButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SoundcheckBox = new System.Windows.Forms.CheckBox();
            this.OrderBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Game = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drops = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ValuecheckBox = new System.Windows.Forms.CheckBox();
            this.EditBlacklistButton = new System.Windows.Forms.Button();
            this.EditSettingsButton = new System.Windows.Forms.Button();
            this.MinimizecheckBox = new System.Windows.Forms.CheckBox();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.GameHeaderBox = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameHeaderBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateButtonWorker
            // 
            this.UpdateButtonWorker.WorkerReportsProgress = true;
            this.UpdateButtonWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateButtonWorker_DoWork);
            this.UpdateButtonWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UpdateButtonWorker_RunWorkerCompleted);
            // 
            // AutoGamesWorker
            // 
            this.AutoGamesWorker.WorkerSupportsCancellation = true;
            this.AutoGamesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AutoGamesWorker_DoWork);
            // 
            // KWorker
            // 
            this.KWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.KWorker_DoWork);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // UpdateButton
            // 
            resources.ApplyResources(this.UpdateButton, "UpdateButton");
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.Update_Click);
            // 
            // StopButton
            // 
            resources.ApplyResources(this.StopButton, "StopButton");
            this.StopButton.Name = "StopButton";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.Stop_Click);
            // 
            // StartButton
            // 
            this.StartButton.AllowDrop = true;
            resources.ApplyResources(this.StartButton, "StartButton");
            this.StartButton.Name = "StartButton";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // AutoModeButton
            // 
            resources.ApplyResources(this.AutoModeButton, "AutoModeButton");
            this.AutoModeButton.Name = "AutoModeButton";
            this.AutoModeButton.UseVisualStyleBackColor = true;
            this.AutoModeButton.Click += new System.EventHandler(this.AutoModeButton_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SoundcheckBox
            // 
            resources.ApplyResources(this.SoundcheckBox, "SoundcheckBox");
            this.SoundcheckBox.Name = "SoundcheckBox";
            this.SoundcheckBox.UseVisualStyleBackColor = true;
            // 
            // OrderBox
            // 
            this.OrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrderBox.FormattingEnabled = true;
            resources.ApplyResources(this.OrderBox, "OrderBox");
            this.OrderBox.Name = "OrderBox";
            this.OrderBox.Sorted = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Game,
            this.ID,
            this.Drops,
            this.Value});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // Game
            // 
            this.Game.DataPropertyName = "Game";
            this.Game.FillWeight = 203.0457F;
            resources.ApplyResources(this.Game, "Game");
            this.Game.Name = "Game";
            this.Game.ReadOnly = true;
            this.Game.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 65.65144F;
            resources.ApplyResources(this.ID, "ID");
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Drops
            // 
            this.Drops.DataPropertyName = "Drops";
            this.Drops.FillWeight = 65.65144F;
            resources.ApplyResources(this.Drops, "Drops");
            this.Drops.Name = "Drops";
            this.Drops.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.FillWeight = 65.65144F;
            resources.ApplyResources(this.Value, "Value");
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // StateLabel
            // 
            this.StateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(163)))), ((int)(((byte)(204)))));
            resources.ApplyResources(this.StateLabel, "StateLabel");
            this.StateLabel.Name = "StateLabel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ValuecheckBox);
            this.groupBox1.Controls.Add(this.EditBlacklistButton);
            this.groupBox1.Controls.Add(this.EditSettingsButton);
            this.groupBox1.Controls.Add(this.MinimizecheckBox);
            this.groupBox1.Controls.Add(this.OrderBox);
            this.groupBox1.Controls.Add(this.SoundcheckBox);
            this.groupBox1.Controls.Add(this.checkBox1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // ValuecheckBox
            // 
            resources.ApplyResources(this.ValuecheckBox, "ValuecheckBox");
            this.ValuecheckBox.Name = "ValuecheckBox";
            this.ValuecheckBox.UseVisualStyleBackColor = true;
            // 
            // EditBlacklistButton
            // 
            resources.ApplyResources(this.EditBlacklistButton, "EditBlacklistButton");
            this.EditBlacklistButton.Name = "EditBlacklistButton";
            this.EditBlacklistButton.UseVisualStyleBackColor = true;
            this.EditBlacklistButton.Click += new System.EventHandler(this.EditBlacklistButton_Click);
            // 
            // EditSettingsButton
            // 
            resources.ApplyResources(this.EditSettingsButton, "EditSettingsButton");
            this.EditSettingsButton.Name = "EditSettingsButton";
            this.EditSettingsButton.UseVisualStyleBackColor = true;
            this.EditSettingsButton.Click += new System.EventHandler(this.EditSettingsButton_Click);
            // 
            // MinimizecheckBox
            // 
            resources.ApplyResources(this.MinimizecheckBox, "MinimizecheckBox");
            this.MinimizecheckBox.Name = "MinimizecheckBox";
            this.MinimizecheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsButton
            // 
            resources.ApplyResources(this.OptionsButton, "OptionsButton");
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.UseVisualStyleBackColor = true;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // GameHeaderBox
            // 
            resources.ApplyResources(this.GameHeaderBox, "GameHeaderBox");
            this.GameHeaderBox.Name = "GameHeaderBox";
            this.GameHeaderBox.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AutoModeButton);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.GameHeaderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GameHeaderBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker AutoGamesWorker;
        private System.ComponentModel.BackgroundWorker KWorker;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox GameHeaderBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button AutoModeButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox SoundcheckBox;
        private System.Windows.Forms.ComboBox OrderBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox MinimizecheckBox;
        private System.Windows.Forms.Button EditSettingsButton;
        private System.Windows.Forms.Button EditBlacklistButton;
        private System.Windows.Forms.CheckBox ValuecheckBox;
        private System.Windows.Forms.Button OptionsButton;
        public System.ComponentModel.BackgroundWorker UpdateButtonWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn Game;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drops;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

