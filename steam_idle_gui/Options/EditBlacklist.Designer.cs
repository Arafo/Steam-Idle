namespace steam_idle_gui
{
    partial class EditBlacklist
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditBlacklist));
            this.GamesComboBox = new System.Windows.Forms.ComboBox();
            this.AddGameButton = new System.Windows.Forms.Button();
            this.GetGamesButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.BlacklistRichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.VACButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamesComboBox
            // 
            this.GamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GamesComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.GamesComboBox, "GamesComboBox");
            this.GamesComboBox.Name = "GamesComboBox";
            // 
            // AddGameButton
            // 
            resources.ApplyResources(this.AddGameButton, "AddGameButton");
            this.AddGameButton.Name = "AddGameButton";
            this.AddGameButton.UseVisualStyleBackColor = true;
            this.AddGameButton.Click += new System.EventHandler(this.AddGameButton_Click);
            // 
            // GetGamesButton
            // 
            resources.ApplyResources(this.GetGamesButton, "GetGamesButton");
            this.GetGamesButton.Name = "GetGamesButton";
            this.GetGamesButton.UseVisualStyleBackColor = true;
            this.GetGamesButton.Click += new System.EventHandler(this.GetGamesButton_Click);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClearButton
            // 
            resources.ApplyResources(this.ClearButton, "ClearButton");
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // BlacklistRichTextBox
            // 
            this.BlacklistRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.BlacklistRichTextBox, "BlacklistRichTextBox");
            this.BlacklistRichTextBox.Name = "BlacklistRichTextBox";
            this.BlacklistRichTextBox.TextChanged += new System.EventHandler(this.BlacklistRichTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BlacklistRichTextBox);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // InfoLabel
            // 
            resources.ApplyResources(this.InfoLabel, "InfoLabel");
            this.InfoLabel.Name = "InfoLabel";
            // 
            // VACButton
            // 
            resources.ApplyResources(this.VACButton, "VACButton");
            this.VACButton.Name = "VACButton";
            this.VACButton.UseVisualStyleBackColor = true;
            this.VACButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // EditBlacklist
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.VACButton);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.GetGamesButton);
            this.Controls.Add(this.AddGameButton);
            this.Controls.Add(this.GamesComboBox);
            this.Name = "EditBlacklist";
            this.Load += new System.EventHandler(this.EditBlacklist_Load);
            this.ParentChanged += new System.EventHandler(this.EditBlacklist_ParentChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox GamesComboBox;
        private System.Windows.Forms.Button AddGameButton;
        private System.Windows.Forms.Button GetGamesButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.RichTextBox BlacklistRichTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Button VACButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
