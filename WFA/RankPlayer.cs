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
    
            if (!string.IsNullOrEmpty(player.Image) && File.Exists(player.Image))
            {
                imgPlayer.Image = Image.FromFile(player.Image);
            }

        }
    }
}
