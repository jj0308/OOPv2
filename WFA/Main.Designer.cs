namespace WFA
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbTeams = new ComboBox();
            flpPlayers = new FlowLayoutPanel();
            flwFavPlayer = new FlowLayoutPanel();
            lblPlayers = new Label();
            lblFavPlayers = new Label();
            btnRank = new Button();
            lblInfo = new Label();
            btncClose = new Button();
            SuspendLayout();
            // 
            // cbTeams
            // 
            cbTeams.FormattingEnabled = true;
            cbTeams.Location = new Point(29, 36);
            cbTeams.Name = "cbTeams";
            cbTeams.Size = new Size(395, 28);
            cbTeams.TabIndex = 0;
            cbTeams.Text = "Choose your favourite team";
            cbTeams.SelectedIndexChanged += cbTeams_SelectedIndexChanged;
            // 
            // flpPlayers
            // 
            flpPlayers.AllowDrop = true;
            flpPlayers.AutoScroll = true;
            flpPlayers.Location = new Point(29, 137);
            flpPlayers.Name = "flpPlayers";
            flpPlayers.Size = new Size(737, 604);
            flpPlayers.TabIndex = 1;
            flpPlayers.DragDrop += flpPlayers_DragDrop;
            flpPlayers.DragOver += flpPlayers_DragOver;
            // 
            // flwFavPlayer
            // 
            flwFavPlayer.AllowDrop = true;
            flwFavPlayer.AutoScroll = true;
            flwFavPlayer.Location = new Point(934, 137);
            flwFavPlayer.Name = "flwFavPlayer";
            flwFavPlayer.Size = new Size(754, 604);
            flwFavPlayer.TabIndex = 2;
            flwFavPlayer.DragDrop += flwFavPlayer_DragDrop;
            flwFavPlayer.DragOver += flwFavPlayer_DragOver;
            // 
            // lblPlayers
            // 
            lblPlayers.AutoSize = true;
            lblPlayers.Location = new Point(29, 98);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(55, 20);
            lblPlayers.TabIndex = 3;
            lblPlayers.Text = "Players";
            // 
            // lblFavPlayers
            // 
            lblFavPlayers.AutoSize = true;
            lblFavPlayers.Location = new Point(934, 98);
            lblFavPlayers.Name = "lblFavPlayers";
            lblFavPlayers.Size = new Size(120, 20);
            lblFavPlayers.TabIndex = 4;
            lblFavPlayers.Text = "Favourite players";
            // 
            // btnRank
            // 
            btnRank.Location = new Point(799, 433);
            btnRank.Name = "btnRank";
            btnRank.Size = new Size(94, 88);
            btnRank.TabIndex = 5;
            btnRank.Text = "Rank";
            btnRank.UseVisualStyleBackColor = true;
            btnRank.Click += btnRank_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(934, 25);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 20);
            lblInfo.TabIndex = 6;
            // 
            // btncClose
            // 
            btncClose.Location = new Point(799, 536);
            btncClose.Name = "btncClose";
            btncClose.Size = new Size(94, 88);
            btncClose.TabIndex = 7;
            btncClose.Text = "Close";
            btncClose.UseVisualStyleBackColor = true;
            btncClose.Click += btncClose_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1700, 753);
            Controls.Add(btncClose);
            Controls.Add(lblInfo);
            Controls.Add(btnRank);
            Controls.Add(lblFavPlayers);
            Controls.Add(lblPlayers);
            Controls.Add(flwFavPlayer);
            Controls.Add(flpPlayers);
            Controls.Add(cbTeams);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTeams;
        private FlowLayoutPanel flpPlayers;
        private FlowLayoutPanel flwFavPlayer;
        private Label lblPlayers;
        private Label lblFavPlayers;
        private Button btnRank;
        private Label lblInfo;
        private Button btncClose;
    }
}