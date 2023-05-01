using DAL.Model;
using DAL.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace DAL
{
    public static class  SetImage
    {

        public static void GetSavedImageIfExsists(Player player)
        {
            List<string> savedPlayersImages = Directory.GetFiles(Constants.Constants.PLAYERS_IMAGES).ToList();

            var playerName = player.Name.ToLower();

            foreach (var item in savedPlayersImages)
            {
                var playerNameFromImage = Path.GetFileNameWithoutExtension(item).ToLower();
                var imageExtension = item.Substring(item.LastIndexOf('.')).ToLower();

                if (playerName == playerNameFromImage)
                {
                    string imagePath = Constants.Constants.PLAYERS_IMAGES + $@"\" + playerNameFromImage + imageExtension;
                   // player.Image = Image.FromFile(imagePath);
                }
            }
        }
    }
}
