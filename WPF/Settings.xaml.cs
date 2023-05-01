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
            cbResolution.Items.Add("1280X720");
            cbResolution.Items.Add("1440X900");
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
            _filePath = Directory.GetParent(_filePath).FullName;
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;

            langFile = _filePath + Constants.PREF_LANG_WPF;
            championShipFile = _filePath + Constants.PREF_CUP_WPF;
            try
            {
                using (StreamWriter writer = new StreamWriter(langFile))
                {
                    if (!File.Exists(langFile)) return;
                    var favLang = cbLang.SelectedItem;
                    writer.WriteLine(favLang);
                }

                using (StreamWriter writer = new StreamWriter(championShipFile))
                {
                    if (!File.Exists(championShipFile)) return;
                    var favCup = cbContest.SelectedItem;
                    writer.WriteLine(favCup);
                }

                using (StreamWriter writer = new StreamWriter(Constants.PREF_RESOLUTION))
                {
                    if (!File.Exists(Constants.PREF_RESOLUTION)) return;
                    var favResolution = cbResolution.SelectedItem;
                    writer.WriteLine(favResolution);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            if (cbLang.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati jezik...", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbLang.Focus();
            }
            if (cbContest.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati prvenstvo...", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbLang.Focus();
            }
            if (cbResolution.SelectedItem == null)
            {
                MessageBox.Show("Morate odabrati rezoluciju...", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                cbLang.Focus();
            }
            else
            {
                MessageBox.Show("Uspješno ste spremili postavke...", "Information!", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }
    }
}
