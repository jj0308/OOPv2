namespace WFA
{
    partial class RankPlayer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankPlayer));
            imgPlayer = new PictureBox();
            lblName = new Label();
            lblApearences = new Label();
            lblScoredGoals = new Label();
            lblYellowCards = new Label();
            rankMatchFrom1 = new RankMatchFrom();
            ((System.ComponentModel.ISupportInitialize)imgPlayer).BeginInit();
            SuspendLayout();
            // 
            // imgPlayer
            // 
            resources.ApplyResources(imgPlayer, "imgPlayer");
            imgPlayer.Image = Properties.Resources.imgPlayer;
            imgPlayer.InitialImage = Properties.Resources.imgPlayer;
            imgPlayer.Name = "imgPlayer";
            imgPlayer.TabStop = false;
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // lblApearences
            // 
            resources.ApplyResources(lblApearences, "lblApearences");
            lblApearences.Name = "lblApearences";
            // 
            // lblScoredGoals
            // 
            resources.ApplyResources(lblScoredGoals, "lblScoredGoals");
            lblScoredGoals.Name = "lblScoredGoals";
            // 
            // lblYellowCards
            // 
            resources.ApplyResources(lblYellowCards, "lblYellowCards");
            lblYellowCards.Name = "lblYellowCards";
            // 
            // rankMatchFrom1
            // 
            resources.ApplyResources(rankMatchFrom1, "rankMatchFrom1");
            rankMatchFrom1.Name = "rankMatchFrom1";
            // 
            // RankPlayer
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(rankMatchFrom1);
            Controls.Add(lblYellowCards);
            Controls.Add(lblScoredGoals);
            Controls.Add(lblApearences);
            Controls.Add(lblName);
            Controls.Add(imgPlayer);
            Name = "RankPlayer";
            ((System.ComponentModel.ISupportInitialize)imgPlayer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox imgPlayer;
        private Label lblName;
        private Label lblApearences;
        private Label lblScoredGoals;
        private Label lblYellowCards;
        private RankMatchFrom rankMatchFrom1;
    }
}
