using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Constants;
using DAL.Model;
using DAL;



namespace WFA
{
    public partial class PlayerControl : UserControl
    {
        private Player _player;
        public bool SelectedPlayer { get; set; }
        public PlayerControl()
        {
            SetSettings.SetCulture(File.ReadLines(DAL.Constants.Constants.PREF_LANG).FirstOrDefault());
            InitializeComponent();
        }

        public PlayerControl(Player player)
        {
            SetSettings.SetCulture(File.ReadLines(DAL.Constants.Constants.PREF_LANG).FirstOrDefault());
            InitializeComponent();
            _player = player;
            lblName.Text = player.Name;
            if (SetSettings.settings.Language == "hr")
            {
                lblCapiten.Text = player.Captain ? "Da" : "Ne";
            }
            else
            {
                lblCapiten.Text = player.Captain ? "Yes" : "No";
            }

            lblNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position;

        }

        public bool Equals(Player player)
        {
            return _player.Name == player.Name &&
                   _player.Captain == player.Captain &&
                   _player.ShirtNumber == player.ShirtNumber &&
                   _player.Position == player.Position;
        }

        private void btnChangeImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"Odaberi format slike|*.jpg;*.jpeg;*.png|Sve|*.*";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != null || openFileDialog.FileName != "")
            {
                ChangeAndSavePlayersImage(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Odabrani format nije podržan!!");
            }


        }
        private void ChangeAndSavePlayersImage(string fileName)
        {

            try
            {
                var imageName = lblName.Text.ToLower();
                var imageExtension = fileName.Substring(fileName.LastIndexOf('.')).ToLower();

                Image playerNewImage = Image.FromFile(fileName);

                pbPlayerImage.Image = playerNewImage;

                string currentDirectory = Directory.GetCurrentDirectory();
                string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DAL.Constants.Constants.IMAGES);
                string settingNewImageName = Path.Combine(folderPath, $"{imageName}{imageExtension}");


                Directory.CreateDirectory(folderPath);

                playerNewImage.Save(settingNewImageName, playerNewImage.RawFormat);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }

        internal void UnselectPlayer()
        {
            BackColor = Color.White;
            SelectedPlayer = false;
        }

        internal void ShowStar()
        {
            lblFav.Text = "*";
        }

        internal void RemoveStar()
        {
            lblFav.Text = "";
        }

        internal string GetPlayer() => $"{lblName.Text}|{lblCapiten.Text}|{lblNumber.Text}|{lblPosition.Text}";

        private void btnChangeImg_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (BackColor == Color.White)
                {
                    BackColor = Color.Yellow;
                    SelectedPlayer = true;
                }
                else
                {
                    BackColor = Color.White;
                    SelectedPlayer = false;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                SelectedPlayer = true;
                BackColor = Color.Beige;
                PlayerControl playerHolder = sender as PlayerControl;
                playerHolder.DoDragDrop(this, DragDropEffects.Move);
            }
        }
    }
}
