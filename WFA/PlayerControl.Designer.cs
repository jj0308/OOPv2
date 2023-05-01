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
            btnChangeImg.Location = new Point(65, 306);
            btnChangeImg.Name = "btnChangeImg";
            btnChangeImg.Size = new Size(152, 36);
            btnChangeImg.TabIndex = 0;
            btnChangeImg.Text = "Change image";
            btnChangeImg.UseVisualStyleBackColor = true;
            btnChangeImg.Click += btnChangeImg_Click;
            btnChangeImg.MouseDown += btnChangeImg_MouseDown;
            // 
            // lblNameL
            // 
            lblNameL.Location = new Point(12, 160);
            lblNameL.Name = "lblNameL";
            lblNameL.Size = new Size(100, 23);
            lblNameL.TabIndex = 3;
            lblNameL.Text = "Name";
            // 
            // lblName
            // 
            lblName.Location = new Point(106, 160);
            lblName.Name = "lblName";
            lblName.Size = new Size(187, 23);
            lblName.TabIndex = 4;
            // 
            // lblNumberL
            // 
            lblNumberL.Location = new Point(12, 205);
            lblNumberL.Name = "lblNumberL";
            lblNumberL.Size = new Size(100, 23);
            lblNumberL.TabIndex = 5;
            lblNumberL.Text = "Number";
            // 
            // lblNumber
            // 
            lblNumber.Location = new Point(106, 189);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(100, 23);
            lblNumber.TabIndex = 10;
            // 
            // lblPositionL
            // 
            lblPositionL.Location = new Point(12, 247);
            lblPositionL.Name = "lblPositionL";
            lblPositionL.Size = new Size(100, 23);
            lblPositionL.TabIndex = 11;
            lblPositionL.Text = "Position";
            // 
            // lblCapitanL
            // 
            lblCapitanL.Location = new Point(13, 280);
            lblCapitanL.Name = "lblCapitanL";
            lblCapitanL.Size = new Size(100, 23);
            lblCapitanL.TabIndex = 12;
            lblCapitanL.Text = "Capitan";
            // 
            // lblCapiten
            // 
            lblCapiten.Location = new Point(106, 280);
            lblCapiten.Name = "lblCapiten";
            lblCapiten.Size = new Size(100, 23);
            lblCapiten.TabIndex = 13;
            // 
            // lblFav
            // 
            lblFav.BackColor = SystemColors.Control;
            lblFav.Font = new Font("Segoe UI", 30F, FontStyle.Bold, GraphicsUnit.Point);
            lblFav.Location = new Point(214, 36);
            lblFav.Name = "lblFav";
            lblFav.Size = new Size(51, 57);
            lblFav.TabIndex = 14;
            lblFav.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPosition
            // 
            lblPosition.Location = new Point(106, 234);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(100, 23);
            lblPosition.TabIndex = 15;
            // 
            // pbPlayerImage
            // 
            pbPlayerImage.Image = (Image)resources.GetObject("pbPlayerImage.Image");
            pbPlayerImage.Location = new Point(12, 9);
            pbPlayerImage.Name = "pbPlayerImage";
            pbPlayerImage.Size = new Size(169, 148);
            pbPlayerImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPlayerImage.TabIndex = 16;
            pbPlayerImage.TabStop = false;
            // 
            // PlayerControl
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
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
            Size = new Size(296, 356);
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
