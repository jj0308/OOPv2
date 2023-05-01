namespace WFA
{
    partial class PlayerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            btnChangeImg = new Button();
            lblNameL = new Label();
            lblName = new Label();
            lblNumberL = new Label();
            lblNumber = new Label();
            lblPositionL = new Label();
            lblCapitanL = new Label();
            lblCapiten = new Label();
            lblFav = new Label();
            lblPosition = new Label();
            pbPlayerImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).BeginInit();
            SuspendLayout();
            // 
            // btnChangeImg
            // 
            resources.ApplyResources(btnChangeImg, "btnChangeImg");
            btnChangeImg.Name = "btnChangeImg";
            btnChangeImg.UseVisualStyleBackColor = true;
            btnChangeImg.Click += btnChangeImg_Click;
            btnChangeImg.MouseDown += btnChangeImg_MouseDown;
            // 
            // lblNameL
            // 
            resources.ApplyResources(lblNameL, "lblNameL");
            lblNameL.Name = "lblNameL";
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // lblNumberL
            // 
            resources.ApplyResources(lblNumberL, "lblNumberL");
            lblNumberL.Name = "lblNumberL";
            // 
            // lblNumber
            // 
            resources.ApplyResources(lblNumber, "lblNumber");
            lblNumber.Name = "lblNumber";
            // 
            // lblPositionL
            // 
            resources.ApplyResources(lblPositionL, "lblPositionL");
            lblPositionL.Name = "lblPositionL";
            // 
            // lblCapitanL
            // 
            resources.ApplyResources(lblCapitanL, "lblCapitanL");
            lblCapitanL.Name = "lblCapitanL";
            // 
            // lblCapiten
            // 
            resources.ApplyResources(lblCapiten, "lblCapiten");
            lblCapiten.Name = "lblCapiten";
            // 
            // lblFav
            // 
            lblFav.BackColor = SystemColors.Control;
            resources.ApplyResources(lblFav, "lblFav");
            lblFav.Name = "lblFav";
            // 
            // lblPosition
            // 
            resources.ApplyResources(lblPosition, "lblPosition");
            lblPosition.Name = "lblPosition";
            // 
            // pbPlayerImage
            // 
            resources.ApplyResources(pbPlayerImage, "pbPlayerImage");
            pbPlayerImage.Name = "pbPlayerImage";
            pbPlayerImage.TabStop = false;
            // 
            // PlayerControl
            // 
            AllowDrop = true;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(pbPlayerImage);
            Controls.Add(lblPosition);
            Controls.Add(lblFav);
            Controls.Add(lblCapiten);
            Controls.Add(lblCapitanL);
            Controls.Add(lblPositionL);
            Controls.Add(lblNumber);
            Controls.Add(lblNumberL);
            Controls.Add(lblName);
            Controls.Add(lblNameL);
            Controls.Add(btnChangeImg);
            Name = "PlayerControl";
            MouseDown += PlayerControl_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pbPlayerImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnChangeImg;
        private Label lblNameL;
        private Label lblName;
        private Label lblNumberL;
        private Label lblNumber;
        private Label lblPositionL;
        private Label lblCapitanL;
        private Label lblCapiten;
        private Label lblFav;
        private Label lblPosition;
        private PictureBox pbPlayerImage;
    }
}
