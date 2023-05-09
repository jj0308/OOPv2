using WFA.Properties;

namespace WFA
{
    partial class CloseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseForm));
            lblMsg = new Label();
            btnYes = new Button();
            btnNo = new Button();
            SuspendLayout();
            // 
            // lblMsg
            // 
            resources.ApplyResources(lblMsg, "lblMsg");
            lblMsg.AutoSize = true;
            lblMsg.ImeMode = ImeMode.NoControl;
            lblMsg.Location = new Point(71, 67);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(211, 20);
            lblMsg.TabIndex = 1;
           
            // 
            // btnYes
            // 
            resources.ApplyResources(btnYes, "btnYes");
            btnYes.ImeMode = ImeMode.NoControl;
            btnYes.Location = new Point(71, 121);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(94, 29);
            btnYes.TabIndex = 2;
        
            btnYes.UseVisualStyleBackColor = true;
            btnYes.Click += btnYes_Click;
            // 
            // btnNo
            // 
            resources.ApplyResources(btnNo, "btnNo");
            btnNo.ImeMode = ImeMode.NoControl;
            btnNo.Location = new Point(188, 121);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(94, 29);
            btnNo.TabIndex = 3;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = true;
            btnNo.Click += btnNo_Click;
            // 
            // CloseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 216);
            Controls.Add(btnNo);
            Controls.Add(btnYes);
            Controls.Add(lblMsg);
            Name = "CloseForm";
            Text = "CloseForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMsg;
        private Button btnYes;
        private Button btnNo;
    }
}