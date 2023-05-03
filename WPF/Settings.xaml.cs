using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAL.Constants;


namespace WPF
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        // File paths for saving settings
        string langFile;
        string championShipFile;
        private string _filePath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        public Settings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateComboBoxLang();
            PopulateComboBoxContest();
            PopulateComboBoxResolution();
        }

        private void PopulateComboBoxResolution()
        {
            cbResolution.Items.Clear();
            InitializeComponent();
            cbResolution.Items.Add("1152X759");
            cbResolution.Items.Add("1920X1080");
            cbResolution.Items.Add("Full-Screen");
        }

        private void PopulateComboBoxContest()
        {
            cbContest.Items.Clear();

            cbContest.Items.Add(Constants.MEN);
            cbContest.Items.Add(Constants.WOMEN);
        }

        private void PopulateComboBoxLang()
        {
            cbLang.Items.Clear();
            InitializeComponent();
            cbLang.Items.Add(Constants.HR);
            cbLang.Items.Add(Constants.EN);
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            langFile = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, Constants.PREF_LANG_WPF));
            championShipFile = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, Constants.PREF_CHAMP_WPF));

            bool langSelected = CheckComboBoxSelection(cbLang, "jezik");
            bool contestSelected = CheckComboBoxSelection(cbContest, "prvenstvo");
            bool resolutionSelected = CheckComboBoxSelection(cbResolution, "rezoluciju");

            if (langSelected && contestSelected && resolutionSelected)
            {
                try
                {
                    WriteToFile(langFile, cbLang.SelectedItem);
                    WriteToFile(championShipFile, cbContest.SelectedItem);
                    WriteToFile(Constants.PREF_RESOLUTION, cbResolution.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message} {ex.StackTrace}");
                }

                MessageBox.Show("Uspješno ste spremili postavke...", "Information!", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
        private void WriteToFile(string filePath, object selectedItem)
        {
            if (selectedItem != null && File.Exists(filePath))
            {
                File.WriteAllText(filePath, selectedItem.ToString());
            }
        }

        private bool CheckComboBoxSelection(ComboBox comboBox, string message)
        {
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show($"Morate odabrati {message}...", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                comboBox.Focus();
                return false;
            }

            return true;
        }
    }
}
