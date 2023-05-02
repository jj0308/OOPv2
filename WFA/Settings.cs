using DAL;
using DAL.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
   
    public partial class Settings : Form
    {
        private DialogResult messageBoxResult;
        public Settings()
        {

          
            
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            messageBoxResult = MessageBox.Show("Are you sure you want this selection?", "Confirmation of selection", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (messageBoxResult == DialogResult.OK)
            {
                SetAndSaveGender(rbMale.Checked ? Constants.MEN : Constants.WOMEN);
                SetAndSaveLanguage(rbCRO.Checked ? Constants.HR : Constants.EN);

                MainForm main = new MainForm();
                main.Show();
                this.Close();
            }


        }


        private void SetAndSaveGender(string gender)
        {
            SetSettings.settings.Gender = gender;
            SaveToFile(gender, Constants.PREF_CHAMP);
        }

        private void SetAndSaveLanguage(string language)
        {
            SetLanguageAndCulture(language);
            SaveToFile(language, Constants.PREF_LANG);
            SetSettings.SetCulture(language);
        }

        private void SaveToFile(string msg, string file)
        {
            try
            {
                File.WriteAllLines(file, new string[] { msg });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}");
            }
        }

        private void SetLanguageAndCulture(string language)
        {
            SetSettings.settings.Language = language;
            SetSettings.SetCulture(language);

        }
    }
}
