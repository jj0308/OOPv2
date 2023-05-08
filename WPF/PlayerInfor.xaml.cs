using DAL;
using DAL.Constants;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using BitmapImage = System.Windows.Media.Imaging.BitmapImage;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PlayerInfor.xaml
    /// </summary>
    public partial class PlayerInfor : Window
    {
        public PlayerInfor(Player player)
        {
            InitializeComponent();
            lblPlayerName.Content = player.Name;
            lblPosition.Content = player.Position;
            lblShirtName.Content = player.ShirtNumber;
            lblCaptain.Content = player.Captain ? "Yes" : "No";
            lblGoals.Content = player.Goals;
            lblYellowCard.Content = player.YellowCards;
            playerImage.Source = GetImageIfExists(player);
        }

        private ImageSource GetImageIfExists(Player player)
        {
            var playerName = player.Name.ToLower();
            string pictureDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.IMAGES);
            List<string> savedPlayersImages = Directory.GetFiles(pictureDirectory).ToList();

            foreach (var item in savedPlayersImages)
            {
                string playerNameFromImage = item.Substring(item.LastIndexOf(@"\")).Replace(@"\", "");
                string[] playerNameData = playerNameFromImage.Split('.');

                if (playerName == playerNameData[0].ToLower())
                {
                    playerImage.Source = new BitmapImage(new Uri(item, UriKind.Absolute));
                    break;
                }
            }
            return playerImage.Source;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
