﻿using DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BitmapImage = System.Windows.Media.Imaging.BitmapImage;

namespace WPF
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        private Player player;
        public PlayerControl(Player player)
        {
            InitializeComponent();
            this.player = player;
            lblPlayerName.Content = player.Name;
            lblShirtNumber.Content = player.ShirtNumber.ToString();
            imgPlayer.Source = GetImageIfExists(player);

        }

        private ImageSource GetImageIfExists(Player player)
        {
            var playerName = player.Name.ToLower();
            string pictureDirectory = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,Constants.IMAGES);

            List<string> savedPlayersImages = Directory.GetFiles(pictureDirectory).ToList();


            foreach (var item in savedPlayersImages)
            {
                string playerNameFromImage = item.Substring(item.LastIndexOf(@"\")).Replace(@"\", "");
                string[] playerNameData = playerNameFromImage.Split('.');

                if (playerName == playerNameData[0].ToLower())
                {
                    imgPlayer.Source = new BitmapImage(new Uri(item, UriKind.Absolute));
                    break;
                }
            }
            return imgPlayer.Source;
        }



        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PlayerInfor playerInfo = new PlayerInfor(player);
            playerInfo.Show();
        }
    }
}
