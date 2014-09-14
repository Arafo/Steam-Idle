namespace steam_idle_gui
{
    partial class Cards
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
            this.CardsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.GetCardsButton = new System.Windows.Forms.Button();
            this.CardsDataGridView = new System.Windows.Forms.DataGridView();
            this.Game = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Card = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CardsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CardsBackgroundWorker
            // 
            this.CardsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CardsBackgroundWorker_DoWork);
            this.CardsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CardsBackgroundWorker_RunWorkerCompleted);
            // 
            // GetCardsButton
            // 
            this.GetCardsButton.Location = new System.Drawing.Point(307, 195);
            this.GetCardsButton.Name = "GetCardsButton";
            this.GetCardsButton.Size = new System.Drawing.Size(75, 23);
            this.GetCardsButton.TabIndex = 0;
            this.GetCardsButton.Text = "Get Cards";
            this.GetCardsButton.UseVisualStyleBackColor = true;
            this.GetCardsButton.Click += new System.EventHandler(this.GetCardsButton_Click);
            // 
            // CardsDataGridView
            // 
            this.CardsDataGridView.AllowUserToAddRows = false;
            this.CardsDataGridView.AllowUserToDeleteRows = false;
            this.CardsDataGridView.AllowUserToResizeRows = false;
            this.CardsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CardsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.CardsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CardsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Game,
            this.Card,
            this.Value});
            this.CardsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.CardsDataGridView.MultiSelect = false;
            this.CardsDataGridView.Name = "CardsDataGridView";
            this.CardsDataGridView.ReadOnly = true;
            this.CardsDataGridView.RowHeadersVisible = false;
            this.CardsDataGridView.Size = new System.Drawing.Size(292, 186);
            this.CardsDataGridView.TabIndex = 1;
            this.CardsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CardsDataGridView_CellClick);
            // 
            // Game
            // 
            this.Game.DataPropertyName = "game";
            this.Game.HeaderText = "Game";
            this.Game.Name = "Game";
            this.Game.ReadOnly = true;
            // 
            // Card
            // 
            this.Card.DataPropertyName = "market_name";
            this.Card.HeaderText = "Card";
            this.Card.Name = "Card";
            this.Card.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // CardPictureBox
            // 
            this.CardPictureBox.Location = new System.Drawing.Point(301, 3);
            this.CardPictureBox.Name = "CardPictureBox";
            this.CardPictureBox.Size = new System.Drawing.Size(81, 102);
            this.CardPictureBox.TabIndex = 2;
            this.CardPictureBox.TabStop = false;
            // 
            // Cards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CardPictureBox);
            this.Controls.Add(this.CardsDataGridView);
            this.Controls.Add(this.GetCardsButton);
            this.Name = "Cards";
            this.Size = new System.Drawing.Size(385, 221);
            this.Load += new System.EventHandler(this.Cards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CardsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker CardsBackgroundWorker;
        private System.Windows.Forms.Button GetCardsButton;
        private System.Windows.Forms.DataGridView CardsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Game;
        private System.Windows.Forms.DataGridViewTextBoxColumn Card;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.PictureBox CardPictureBox;
    }
}
