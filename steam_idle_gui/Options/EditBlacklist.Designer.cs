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
            this.WhilelistCheckBox = new System.Windows.Forms.CheckBox();
            this.BlacklistRichTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamesComboBox
            // 
            resources.ApplyResources(this.GamesComboBox, "GamesComboBox");
            this.GamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GamesComboBox.FormattingEnabled = true;
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
            // WhilelistCheckBox
            // 
            resources.ApplyResources(this.WhilelistCheckBox, "WhilelistCheckBox");
            this.WhilelistCheckBox.Name = "WhilelistCheckBox";
            this.WhilelistCheckBox.UseVisualStyleBackColor = true;
            // 
            // BlacklistRichTextBox
            // 
            resources.ApplyResources(this.BlacklistRichTextBox, "BlacklistRichTextBox");
            this.BlacklistRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BlacklistRichTextBox.Name = "BlacklistRichTextBox";
            this.BlacklistRichTextBox.TextChanged += new System.EventHandler(this.BlacklistRichTextBox_TextChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BlacklistRichTextBox);
            this.panel1.Name = "panel1";
            // 
            // InfoLabel
            // 
            resources.ApplyResources(this.InfoLabel, "InfoLabel");
            this.InfoLabel.Name = "InfoLabel";
            // 
            // EditBlacklist
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.WhilelistCheckBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.GetGamesButton);
            this.Controls.Add(this.AddGameButton);
            this.Controls.Add(this.GamesComboBox);
            this.Name = "EditBlacklist";
            this.Load += new System.EventHandler(this.EditBlacklist_Load);
            this.VisibleChanged += new System.EventHandler(this.EditBlacklist_VisibleChanged);
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
        private System.Windows.Forms.CheckBox WhilelistCheckBox;
        private System.Windows.Forms.RichTextBox BlacklistRichTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label InfoLabel;
    }
}
