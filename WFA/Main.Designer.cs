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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
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
            resources.ApplyResources(cbTeams, "cbTeams");
            cbTeams.Name = "cbTeams";
            cbTeams.SelectedIndexChanged += cbTeams_SelectedIndexChanged;
            // 
            // flpPlayers
            // 
            flpPlayers.AllowDrop = true;
            resources.ApplyResources(flpPlayers, "flpPlayers");
            flpPlayers.Name = "flpPlayers";
            flpPlayers.DragDrop += flpPlayers_DragDrop;
            flpPlayers.DragOver += flpPlayers_DragOver;
            // 
            // flwFavPlayer
            // 
            flwFavPlayer.AllowDrop = true;
            resources.ApplyResources(flwFavPlayer, "flwFavPlayer");
            flwFavPlayer.Name = "flwFavPlayer";
            flwFavPlayer.DragDrop += flwFavPlayer_DragDrop;
            flwFavPlayer.DragOver += flwFavPlayer_DragOver;
            // 
            // lblPlayers
            // 
            resources.ApplyResources(lblPlayers, "lblPlayers");
            lblPlayers.Name = "lblPlayers";
            // 
            // lblFavPlayers
            // 
            resources.ApplyResources(lblFavPlayers, "lblFavPlayers");
            lblFavPlayers.Name = "lblFavPlayers";
            // 
            // btnRank
            // 
            resources.ApplyResources(btnRank, "btnRank");
            btnRank.Name = "btnRank";
            btnRank.UseVisualStyleBackColor = true;
            btnRank.Click += btnRank_Click;
            // 
            // lblInfo
            // 
            resources.ApplyResources(lblInfo, "lblInfo");
            lblInfo.Name = "lblInfo";
            // 
            // btncClose
            // 
            resources.ApplyResources(btncClose, "btncClose");
            btncClose.Name = "btncClose";
            btncClose.UseVisualStyleBackColor = true;
            btncClose.Click += btncClose_Click;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btncClose);
            Controls.Add(lblInfo);
            Controls.Add(btnRank);
            Controls.Add(lblFavPlayers);
            Controls.Add(lblPlayers);
            Controls.Add(flwFavPlayer);
            Controls.Add(flpPlayers);
            Controls.Add(cbTeams);
            Name = "Main";
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