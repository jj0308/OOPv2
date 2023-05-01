namespace WFA
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            btnNext = new Button();
            groupBoxLang = new GroupBox();
            rbCRO = new RadioButton();
            rbEng = new RadioButton();
            groupBoxGen = new GroupBox();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            groupBoxLang.SuspendLayout();
            groupBoxGen.SuspendLayout();
            SuspendLayout();
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.Name = "btnNext";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // groupBoxLang
            // 
            resources.ApplyResources(groupBoxLang, "groupBoxLang");
            groupBoxLang.Controls.Add(rbCRO);
            groupBoxLang.Controls.Add(rbEng);
            groupBoxLang.Name = "groupBoxLang";
            groupBoxLang.TabStop = false;
            // 
            // rbCRO
            // 
            resources.ApplyResources(rbCRO, "rbCRO");
            rbCRO.Checked = true;
            rbCRO.Name = "rbCRO";
            rbCRO.TabStop = true;
            rbCRO.UseVisualStyleBackColor = true;
            // 
            // rbEng
            // 
            resources.ApplyResources(rbEng, "rbEng");
            rbEng.Name = "rbEng";
            rbEng.UseVisualStyleBackColor = true;
            // 
            // groupBoxGen
            // 
            resources.ApplyResources(groupBoxGen, "groupBoxGen");
            groupBoxGen.Controls.Add(rbFemale);
            groupBoxGen.Controls.Add(rbMale);
            groupBoxGen.Name = "groupBoxGen";
            groupBoxGen.TabStop = false;
            // 
            // rbFemale
            // 
            resources.ApplyResources(rbFemale, "rbFemale");
            rbFemale.Name = "rbFemale";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            resources.ApplyResources(rbMale, "rbMale");
            rbMale.Checked = true;
            rbMale.Name = "rbMale";
            rbMale.TabStop = true;
            rbMale.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxGen);
            Controls.Add(groupBoxLang);
            Controls.Add(btnNext);
            Name = "Settings";
            groupBoxLang.ResumeLayout(false);
            groupBoxLang.PerformLayout();
            groupBoxGen.ResumeLayout(false);
            groupBoxGen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNext;
        private GroupBox groupBoxLang;
        private GroupBox groupBoxGen;
        private RadioButton rbCRO;
        private RadioButton rbEng;
        private RadioButton rbFemale;
        private RadioButton rbMale;
    }
}