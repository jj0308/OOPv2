namespace WFA
{
    partial class RankMatchFrom
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
            lblLocation = new Label();
            lblAttendance = new Label();
            lblHomeTeam = new Label();
            lblAwayTeam = new Label();
            SuspendLayout();
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(3, 17);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(66, 20);
            lblLocation.TabIndex = 0;
            lblLocation.Text = "Location";
            // 
            // lblAttendance
            // 
            lblAttendance.AutoSize = true;
            lblAttendance.Location = new Point(347, 17);
            lblAttendance.Name = "lblAttendance";
            lblAttendance.Size = new Size(86, 20);
            lblAttendance.TabIndex = 1;
            lblAttendance.Text = "Posjecenost";
            // 
            // lblHomeTeam
            // 
            lblHomeTeam.AutoSize = true;
            lblHomeTeam.Location = new Point(510, 17);
            lblHomeTeam.Name = "lblHomeTeam";
            lblHomeTeam.Size = new Size(97, 20);
            lblHomeTeam.TabIndex = 2;
            lblHomeTeam.Text = "DomaciTeam";
            // 
            // lblAwayTeam
            // 
            lblAwayTeam.AutoSize = true;
            lblAwayTeam.Location = new Point(667, 17);
            lblAwayTeam.Name = "lblAwayTeam";
            lblAwayTeam.Size = new Size(106, 20);
            lblAwayTeam.TabIndex = 3;
            lblAwayTeam.Text = "GostujuciTeam";
            // 
            // RankMatchFrom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblAwayTeam);
            Controls.Add(lblHomeTeam);
            Controls.Add(lblAttendance);
            Controls.Add(lblLocation);
            Name = "RankMatchFrom";
            Size = new Size(787, 57);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLocation;
        private Label lblAttendance;
        private Label lblHomeTeam;
        private Label lblAwayTeam;
    }
}
