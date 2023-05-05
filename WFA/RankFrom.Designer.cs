namespace WFA
{
    partial class RankFrom
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankFrom));
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            changeSettingsToolStripMenuItem = new ToolStripMenuItem();
            closeAppToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem1 = new ToolStripMenuItem();
            tabControl = new TabControl();
            tabPlayers = new TabPage();
            lblSortPlayerMsg = new Label();
            pnlPlayers = new FlowLayoutPanel();
            gbGoals = new GroupBox();
            label5 = new Label();
            rbYCDDesc = new RadioButton();
            rbYcAsc = new RadioButton();
            rbGoalsAsc = new RadioButton();
            rbGoalsDesc = new RadioButton();
            lblYellowCards = new Label();
            lblScoredGoals = new Label();
            lblApperiance = new Label();
            lblName = new Label();
            lblSortPlayers = new Label();
            tabMatches = new TabPage();
            lblMsg = new Label();
            pnlMatches = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            gbAudience = new GroupBox();
            rbAudienceAsc = new RadioButton();
            rbAudienceDesc = new RadioButton();
            lblSortMatches = new Label();
            menuStrip1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPlayers.SuspendLayout();
            gbGoals.SuspendLayout();
            tabMatches.SuspendLayout();
            gbAudience.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, printToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changeSettingsToolStripMenuItem, closeAppToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // changeSettingsToolStripMenuItem
            // 
            changeSettingsToolStripMenuItem.Name = "changeSettingsToolStripMenuItem";
            resources.ApplyResources(changeSettingsToolStripMenuItem, "changeSettingsToolStripMenuItem");
            changeSettingsToolStripMenuItem.Click += changeSettingsToolStripMenuItem_Click;
            // 
            // closeAppToolStripMenuItem
            // 
            closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            resources.ApplyResources(closeAppToolStripMenuItem, "closeAppToolStripMenuItem");
            closeAppToolStripMenuItem.Click += closeAppToolStripMenuItem_Click;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { printToolStripMenuItem1 });
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(printToolStripMenuItem, "printToolStripMenuItem");
            // 
            // printToolStripMenuItem1
            // 
            printToolStripMenuItem1.Name = "printToolStripMenuItem1";
            resources.ApplyResources(printToolStripMenuItem1, "printToolStripMenuItem1");
            printToolStripMenuItem1.Click += printToolStripMenuItem1_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPlayers);
            tabControl.Controls.Add(tabMatches);
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(lblSortPlayerMsg);
            tabPlayers.Controls.Add(pnlPlayers);
            tabPlayers.Controls.Add(gbGoals);
            tabPlayers.Controls.Add(lblYellowCards);
            tabPlayers.Controls.Add(lblScoredGoals);
            tabPlayers.Controls.Add(lblApperiance);
            tabPlayers.Controls.Add(lblName);
            tabPlayers.Controls.Add(lblSortPlayers);
            resources.ApplyResources(tabPlayers, "tabPlayers");
            tabPlayers.Name = "tabPlayers";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // lblSortPlayerMsg
            // 
            resources.ApplyResources(lblSortPlayerMsg, "lblSortPlayerMsg");
            lblSortPlayerMsg.Name = "lblSortPlayerMsg";
            // 
            // pnlPlayers
            // 
            resources.ApplyResources(pnlPlayers, "pnlPlayers");
            pnlPlayers.Name = "pnlPlayers";
            // 
            // gbGoals
            // 
            gbGoals.Controls.Add(label5);
            gbGoals.Controls.Add(rbYCDDesc);
            gbGoals.Controls.Add(rbYcAsc);
            gbGoals.Controls.Add(rbGoalsAsc);
            gbGoals.Controls.Add(rbGoalsDesc);
            resources.ApplyResources(gbGoals, "gbGoals");
            gbGoals.Name = "gbGoals";
            gbGoals.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // rbYCDDesc
            // 
            resources.ApplyResources(rbYCDDesc, "rbYCDDesc");
            rbYCDDesc.Name = "rbYCDDesc";
            rbYCDDesc.UseVisualStyleBackColor = true;
            rbYCDDesc.CheckedChanged += rbYCDDesc_CheckedChanged;
            // 
            // rbYcAsc
            // 
            resources.ApplyResources(rbYcAsc, "rbYcAsc");
            rbYcAsc.Name = "rbYcAsc";
            rbYcAsc.UseVisualStyleBackColor = true;
            rbYcAsc.CheckedChanged += rbYcAsc_CheckedChanged;
            // 
            // rbGoalsAsc
            // 
            resources.ApplyResources(rbGoalsAsc, "rbGoalsAsc");
            rbGoalsAsc.Checked = true;
            rbGoalsAsc.Name = "rbGoalsAsc";
            rbGoalsAsc.TabStop = true;
            rbGoalsAsc.UseVisualStyleBackColor = true;
            rbGoalsAsc.CheckedChanged += rbGoalsAsc_CheckedChanged;
            // 
            // rbGoalsDesc
            // 
            resources.ApplyResources(rbGoalsDesc, "rbGoalsDesc");
            rbGoalsDesc.Name = "rbGoalsDesc";
            rbGoalsDesc.UseVisualStyleBackColor = true;
            rbGoalsDesc.CheckedChanged += rbGoalsDesc_CheckedChanged;
            // 
            // lblYellowCards
            // 
            resources.ApplyResources(lblYellowCards, "lblYellowCards");
            lblYellowCards.Name = "lblYellowCards";
            // 
            // lblScoredGoals
            // 
            resources.ApplyResources(lblScoredGoals, "lblScoredGoals");
            lblScoredGoals.Name = "lblScoredGoals";
            // 
            // lblApperiance
            // 
            resources.ApplyResources(lblApperiance, "lblApperiance");
            lblApperiance.Name = "lblApperiance";
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // lblSortPlayers
            // 
            resources.ApplyResources(lblSortPlayers, "lblSortPlayers");
            lblSortPlayers.Name = "lblSortPlayers";
            // 
            // tabMatches
            // 
            tabMatches.Controls.Add(lblMsg);
            tabMatches.Controls.Add(pnlMatches);
            tabMatches.Controls.Add(label1);
            tabMatches.Controls.Add(label2);
            tabMatches.Controls.Add(label3);
            tabMatches.Controls.Add(label4);
            tabMatches.Controls.Add(gbAudience);
            tabMatches.Controls.Add(lblSortMatches);
            resources.ApplyResources(tabMatches, "tabMatches");
            tabMatches.Name = "tabMatches";
            tabMatches.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            resources.ApplyResources(lblMsg, "lblMsg");
            lblMsg.Name = "lblMsg";
            // 
            // pnlMatches
            // 
            resources.ApplyResources(pnlMatches, "pnlMatches");
            pnlMatches.Name = "pnlMatches";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // gbAudience
            // 
            gbAudience.Controls.Add(rbAudienceAsc);
            gbAudience.Controls.Add(rbAudienceDesc);
            resources.ApplyResources(gbAudience, "gbAudience");
            gbAudience.Name = "gbAudience";
            gbAudience.TabStop = false;
            // 
            // rbAudienceAsc
            // 
            resources.ApplyResources(rbAudienceAsc, "rbAudienceAsc");
            rbAudienceAsc.Checked = true;
            rbAudienceAsc.Name = "rbAudienceAsc";
            rbAudienceAsc.TabStop = true;
            rbAudienceAsc.UseVisualStyleBackColor = true;
            rbAudienceAsc.CheckedChanged += rbAudienceAsc_CheckedChanged;
            // 
            // rbAudienceDesc
            // 
            resources.ApplyResources(rbAudienceDesc, "rbAudienceDesc");
            rbAudienceDesc.Name = "rbAudienceDesc";
            rbAudienceDesc.UseVisualStyleBackColor = true;
            rbAudienceDesc.CheckedChanged += rbAudienceDesc_CheckedChanged;
            // 
            // lblSortMatches
            // 
            resources.ApplyResources(lblSortMatches, "lblSortMatches");
            lblSortMatches.Name = "lblSortMatches";
            // 
            // RankFrom
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "RankFrom";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabPlayers.PerformLayout();
            gbGoals.ResumeLayout(false);
            gbGoals.PerformLayout();
            tabMatches.ResumeLayout(false);
            tabMatches.PerformLayout();
            gbAudience.ResumeLayout(false);
            gbAudience.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem changeSettingsToolStripMenuItem;
        private ToolStripMenuItem closeAppToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem1;
        private TabControl tabControl;
        private TabPage tabPlayers;
        private TabPage tabMatches;
        private Label lblSortPlayers;
        private ComboBox cbSortMatches;
        private Label lblYellowCards;
        private Label lblScoredGoals;
        private Label lblApperiance;
        private Label lblName;
        private GroupBox gbGoals;
        private RadioButton rbdAsc;
        private RadioButton rbDesc;
        private RadioButton radioButton1;
        private GroupBox gbAudience;
        private RadioButton rbAudienceAsc;
        private RadioButton rbAudienceDesc;
        private FlowLayoutPanel pnlPlayers;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RadioButton rbGoalsAsc;
        private RadioButton rbGoalsDesc;
        private FlowLayoutPanel pnlMatches;
        private RadioButton rbYCDDesc;
        private RadioButton rbYcAsc;
        private Label lblSortMatches;
        private Label lblMsg;
        private Label lblSortPlayerMsg;
        private Label label5;
    }
}