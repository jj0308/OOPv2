using DAL.Constants;
using DAL.Model;
using iText.Kernel.Pdf.Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace WFA
{
    public partial class RankPlayer : UserControl
    {
        public string PlayerName
        {
            get { return lblName.Text; }
        }

        public int PlayerGoals
        {
            get { return int.TryParse(lblScoredGoals.Text, out int goals) ? goals : 0; }
        }

        public int PlayerYellowCards
        {
            get { return int.TryParse(lblYellowCards.Text, out int yellowCards) ? yellowCards : 0; }
        }

        public int PlayerAppearances
        {
            get { return int.TryParse(lblApearences.Text, out int appearances) ? appearances : 0; }
        }

        public RankPlayer()
        {
            InitializeComponent();
        }

        public RankPlayer(Player player)
        {
            InitializeComponent();
            lblName.Text = player.Name;
            lblYellowCards.Text = player.YellowCards.ToString();
            lblScoredGoals.Text = player.Goals.ToString();
            lblApearences.Text = player.Appearances.ToString();
            Image img = GetSavedImageIfExsists(player);
            if (img != null)
            {
                imgPlayer.Image = img;
                imgPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            }



        }

        private Image GetSavedImageIfExsists(Player player)
        {
            try
            {
                string imagesFolderPath = GetImagesFolderPath();
                List<string> savedPlayersImages = Directory.GetFiles(imagesFolderPath).ToList();

                var playerName = player.Name.ToLower();

                foreach (var item in savedPlayersImages)
                {
                    var playerNameFromImage = Path.GetFileNameWithoutExtension(item).ToLower();
                    var imageExtension = item.Substring(item.LastIndexOf('.')).ToLower();

                    if (playerName == playerNameFromImage)
                    {
                        return Image.FromFile(item);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return null;
        }


        private string GetImagesFolderPath()
        {
            
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,Constants.IMAGES);
            return folderPath;
        }

    }
}
