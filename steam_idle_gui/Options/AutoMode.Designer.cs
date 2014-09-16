namespace steam_idle_gui
{
    partial class AutoMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoMode));
            this.UpdateGroupBox = new System.Windows.Forms.GroupBox();
            this.ValueCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoModeGroupBox = new System.Windows.Forms.GroupBox();
            this.OrderLabel = new System.Windows.Forms.Label();
            this.OrderBox = new System.Windows.Forms.ComboBox();
            this.GeneralGroupBox = new System.Windows.Forms.GroupBox();
            this.LogCheckBox = new System.Windows.Forms.CheckBox();
            this.MinimizeCheckBox = new System.Windows.Forms.CheckBox();
            this.SoundCheckBox = new System.Windows.Forms.CheckBox();
            this.HideCheckBox = new System.Windows.Forms.CheckBox();
            this.UpdateGroupBox.SuspendLayout();
            this.AutoModeGroupBox.SuspendLayout();
            this.GeneralGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateGroupBox
            // 
            resources.ApplyResources(this.UpdateGroupBox, "UpdateGroupBox");
            this.UpdateGroupBox.Controls.Add(this.ValueCheckBox);
            this.UpdateGroupBox.Name = "UpdateGroupBox";
            this.UpdateGroupBox.TabStop = false;
            // 
            // ValueCheckBox
            // 
            resources.ApplyResources(this.ValueCheckBox, "ValueCheckBox");
            this.ValueCheckBox.Name = "ValueCheckBox";
            this.ValueCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoModeGroupBox
            // 
            resources.ApplyResources(this.AutoModeGroupBox, "AutoModeGroupBox");
            this.AutoModeGroupBox.Controls.Add(this.OrderLabel);
            this.AutoModeGroupBox.Controls.Add(this.OrderBox);
            this.AutoModeGroupBox.Name = "AutoModeGroupBox";
            this.AutoModeGroupBox.TabStop = false;
            // 
            // OrderLabel
            // 
            resources.ApplyResources(this.OrderLabel, "OrderLabel");
            this.OrderLabel.Name = "OrderLabel";
            // 
            // OrderBox
            // 
            resources.ApplyResources(this.OrderBox, "OrderBox");
            this.OrderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OrderBox.Items.AddRange(new object[] {
            resources.GetString("OrderBox.Items"),
            resources.GetString("OrderBox.Items1"),
            resources.GetString("OrderBox.Items2"),
            resources.GetString("OrderBox.Items3"),
            resources.GetString("OrderBox.Items4"),
            resources.GetString("OrderBox.Items5")});
            this.OrderBox.Name = "OrderBox";
            // 
            // GeneralGroupBox
            // 
            resources.ApplyResources(this.GeneralGroupBox, "GeneralGroupBox");
            this.GeneralGroupBox.Controls.Add(this.LogCheckBox);
            this.GeneralGroupBox.Controls.Add(this.MinimizeCheckBox);
            this.GeneralGroupBox.Controls.Add(this.SoundCheckBox);
            this.GeneralGroupBox.Controls.Add(this.HideCheckBox);
            this.GeneralGroupBox.Name = "GeneralGroupBox";
            this.GeneralGroupBox.TabStop = false;
            // 
            // LogCheckBox
            // 
            resources.ApplyResources(this.LogCheckBox, "LogCheckBox");
            this.LogCheckBox.Name = "LogCheckBox";
            this.LogCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinimizeCheckBox
            // 
            resources.ApplyResources(this.MinimizeCheckBox, "MinimizeCheckBox");
            this.MinimizeCheckBox.Name = "MinimizeCheckBox";
            this.MinimizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // SoundCheckBox
            // 
            resources.ApplyResources(this.SoundCheckBox, "SoundCheckBox");
            this.SoundCheckBox.Name = "SoundCheckBox";
            this.SoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // HideCheckBox
            // 
            resources.ApplyResources(this.HideCheckBox, "HideCheckBox");
            this.HideCheckBox.Name = "HideCheckBox";
            this.HideCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoMode
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AutoModeGroupBox);
            this.Controls.Add(this.GeneralGroupBox);
            this.Controls.Add(this.UpdateGroupBox);
            this.Name = "AutoMode";
            this.Load += new System.EventHandler(this.AutoMode_Load);
            this.VisibleChanged += new System.EventHandler(this.AutoMode_VisibleChanged);
            this.UpdateGroupBox.ResumeLayout(false);
            this.UpdateGroupBox.PerformLayout();
            this.AutoModeGroupBox.ResumeLayout(false);
            this.AutoModeGroupBox.PerformLayout();
            this.GeneralGroupBox.ResumeLayout(false);
            this.GeneralGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UpdateGroupBox;
        private System.Windows.Forms.CheckBox ValueCheckBox;
        private System.Windows.Forms.GroupBox AutoModeGroupBox;
        private System.Windows.Forms.Label OrderLabel;
        private System.Windows.Forms.ComboBox OrderBox;
        private System.Windows.Forms.GroupBox GeneralGroupBox;
        private System.Windows.Forms.CheckBox MinimizeCheckBox;
        private System.Windows.Forms.CheckBox SoundCheckBox;
        private System.Windows.Forms.CheckBox HideCheckBox;
        private System.Windows.Forms.CheckBox LogCheckBox;
    }
}
