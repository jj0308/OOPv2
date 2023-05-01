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
        public Settings()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                SetSettings.settings.Gender = Constants.MEN;
                SaveToFile(Constants.MEN, Constants.PREF_CHAMP);
               
            }
            else if (rbFemale.Checked)
            {
                SetSettings.settings.Gender = Constants.WOMEN;
                SaveToFile(Constants.WOMEN, Constants.PREF_CHAMP);
            }

            if (rbCRO.Checked)
            {
                SetLanguageAndCulture(Constants.HR);
                SaveToFile(Constants.HR, Constants.PREF_LANG);
                SetSettings.SetCulture(Constants.HR);
            }
            else if (rbEng.Checked)
            {
                SetLanguageAndCulture(Constants.EN);
                SaveToFile(Constants.EN, Constants.PREF_CHAMP);
                SetSettings.SetCulture(Constants.EN);
            }

            this.Hide();
            Main main = new Main();
            main.Show();
            this.Close();

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
