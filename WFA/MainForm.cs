using DAL.Model;
using DAL;
using DAL.Constants;
using DAL.Repo;
using System.Diagnostics;
using System.Diagnostics.Metrics;


namespace WFA
{
    public partial class MainForm : Form
    {
        private Countries selectedCountry;
        private IList<Player> allTeamsPlayers = new List<Player>();
        private List<Countries> countries = new List<Countries>();
        string championShipFile;
        string favoritePlayersFile;
        public MainForm()
        {

            CheckIfSettingsFileExists();
            SetSettings.SetCulture(File.ReadLines(Constants.PREF_LANG).FirstOrDefault());
            InitializeComponent();
        }

        private void CheckIfSettingsFileExists()
        {
            if (!File.Exists(Constants.PREF_CHAMP) || !File.Exists(Constants.PREF_LANG))
            {
                Settings settingsForm = new Settings();
                settingsForm.ShowDialog();
            }
        }


        private async void Main_Load(object sender, EventArgs e)
        {


            btnRank.Enabled = false;


            if (Constants.GetLanguage() == "en")
            {
                lblInfo.Text = "I'm retrieving data on national teams...";
            }
            else
            {
                lblInfo.Text = "Dohvaæam podatke o reprezentacijama...";
            }

            if (File.ReadLines(Constants.PREF_CHAMP).FirstOrDefault() == "men")
            {
                championShipFile = Constants.FAVTEAM_MEN;
                favoritePlayersFile = Constants.FAVPLAYERS_MEN;
            }
            else
            {
                championShipFile = Constants.FAVTEAM_WOMEN;
                favoritePlayersFile = Constants.FAVPLAYERS_WOMEN;
            }


            //dohvat svih država (reprezentacija)
            try
            {
                WCREPO wcrepo = new WCREPO();
                countries = await wcrepo.GetAllCountries(Constants.GetCountriesByGender());
                foreach (var item in countries)
                {
                    cbTeams.Items.Add(item);
                }
                lblInfo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} jure je");
            }


            //Provjera text file - a ako postoji zapis o omiljenom timu i omiljeni igraèima

            try
            {
                if (!File.Exists(championShipFile) || new FileInfo(championShipFile).Length == 0)
                {
                    return;
                }

                var lines = File.ReadAllLines(championShipFile);
                GetFavoriteTeamFromFile(lines);

                if (!File.Exists(favoritePlayersFile) || new FileInfo(favoritePlayersFile).Length == 0)
                {
                    return;
                }

                var linesPlayers = File.ReadAllLines(favoritePlayersFile);
                GetFavoritePlayersFromFile(linesPlayers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} ovo je test");
            }


        }

        private void GetFavoritePlayersFromFile(string[] linesPlayers)
        {
            foreach (var player in linesPlayers)
            {
                string[] details = player.Split(Constants.DEL);

                PlayerControl playerControl = new PlayerControl(new Player
                {
                    Name = details[0],
                    Captain = details[1].Equals("NE") ? true : false,
                    ShirtNumber = int.Parse(details[2]),
                    Position = details[3],
                    FavouritePlayer = true
                });
                flwFavPlayer.Controls.Add(playerControl);
            }
        }

        private void cbTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedCountry = cbTeams.SelectedItem as Countries;
                string fifa_code = selectedCountry.FifaCode;
                string country = selectedCountry.Country;
                flpPlayers.Controls.Clear();
                flwFavPlayer.Controls.Clear();
                FillPanelWithPlayers(fifa_code, country);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        private void GetFavoriteTeamFromFile(string[] lines)
        {
            foreach (var line in lines)
            {
                string[] data = line.Split('(');
                var country = data[0].Substring(0, data[0].Length - 1);
                var fifa_code = data[1].Substring(0, data[1].Length - 1);
                
                foreach (var item in countries)
                {
                    if (item.Country.Equals(country))
                        cbTeams.SelectedItem = item;
                }
                FillPanelWithPlayers(fifa_code, country);
            }
        }

        private async void FillPanelWithPlayers(string fifa_code, string country)
        {
            try
            {
                WCREPO wCREPO = new WCREPO();
                string link = Constants.GetMatchesByGender() + fifa_code;
                List<SoccerMatch> soccerMatches = await wCREPO.GetAllTeamPlayers(link);

                allTeamsPlayers = GetAllTeamsPlayers(soccerMatches, country);
                List<PlayerControl> favoritePlayers = new();
                foreach (PlayerControl control in flwFavPlayer.Controls)
                {
                    favoritePlayers.Add(control);
                }

                foreach (var item in allTeamsPlayers)
                {
                    bool isFavorite = favoritePlayers.Exists(fp => fp.Equals(new Player
                    {
                        Name = item.Name,
                        Captain = item.Captain,
                        ShirtNumber = item.ShirtNumber,
                        Position = item.Position
                    }));

                    if (!isFavorite)
                    {
                        PlayerControl playerControl = new PlayerControl(new Player
                        {
                            Name = item.Name,
                            Captain = item.Captain,
                            ShirtNumber = item.ShirtNumber,
                            Position = item.Position
                        });
                        flpPlayers.Controls.Add(playerControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            btnRank.Enabled = true;

        }

        //dohvat pocetnih 11 i Zamjena
        private IList<Player> GetAllTeamsPlayers(List<SoccerMatch> soccerMatches, string country)
        {
            try
            {
                SoccerMatch soccerGame = soccerMatches.FirstOrDefault();
                if (soccerGame.HomeTeam.Country == country)
                {
                    return new List<Player>(soccerGame.HomeTeamStatistics.StartingEleven.Union(soccerGame.HomeTeamStatistics.Substitutes));
                }
                if (soccerGame.AwayTeam.Country == country)
                {
                    return new List<Player>(soccerGame.AwayTeamStatistics.StartingEleven.Union(soccerGame.AwayTeamStatistics.Substitutes));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            return new List<Player>();
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Drag drop 
        private void flwFavPlayer_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flwFavPlayer_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                List<PlayerControl> favoritPlayers = GetSelectedPlayersToFavorit(flpPlayers);
                if (!CountOfMaximumFavoritPlayers(favoritPlayers))
                {
                    MessageBox.Show("Dozvoljeno je dodati samo 3 omiljena igraèa!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (flwFavPlayer.Controls.Count < 3)
                    {
                        MovingSelectedPlayersToFavoritPanel(favoritPlayers, flpPlayers, flwFavPlayer);
                    }
                    else
                    {
                        MessageBox.Show("Dodali ste veæ 3 omiljena igraèa!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        foreach (PlayerControl item in favoritPlayers)
                        {
                            item.UnselectPlayer();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void flpPlayers_DragDrop(object sender, DragEventArgs e)
        {
            List<PlayerControl> favoritPlayers = GetSelectedPlayersToFavorit(flwFavPlayer);
            MovingSelectedPlayersFromFavoritPanel(favoritPlayers, flwFavPlayer, flpPlayers);
        }

        private void flpPlayers_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Drag drop methode
        private bool CountOfMaximumFavoritPlayers(List<PlayerControl> favoritPlayers)
        {
            if (favoritPlayers.Count > 3)
            {
                foreach (PlayerControl item in favoritPlayers)
                {
                    item.UnselectPlayer();
                }
                return false;
            }
            return true;
        }

        //Dodavanje igraèa u listu igraèa Favorita
        private List<PlayerControl> GetSelectedPlayersToFavorit(FlowLayoutPanel flpAllTeamPlayers)
        {
            List<PlayerControl> favoritPlayersToList = new List<PlayerControl>();

            foreach (PlayerControl player in flpAllTeamPlayers.Controls)
            {
                if (player.SelectedPlayer)
                {
                    favoritPlayersToList.Add(player);
                }
            }
            return favoritPlayersToList;
        }

        //Uklanjanje igraèa iz Panela Favorita
        private void MovingSelectedPlayersFromFavoritPanel(List<PlayerControl> favoritPlayers, FlowLayoutPanel flpFavoritePlayers, FlowLayoutPanel flpAllTeamPlayers)
        {
            foreach (PlayerControl item in favoritPlayers)
            {
                if (item.SelectedPlayer)
                {
                    item.UnselectPlayer();
                }
                flpAllTeamPlayers.Controls.Add(item);
                flpFavoritePlayers.Controls.Remove(item);
                item.RemoveStar();
            }
        }

        //Prebacivanje selektiranih igraèa u Panel Favorita
        private void MovingSelectedPlayersToFavoritPanel(List<PlayerControl> favoritPlayers, FlowLayoutPanel flpAllTeamPlayers, FlowLayoutPanel flpFavoritePlayers)
        {
            foreach (PlayerControl item in favoritPlayers)
            {
                if (item.SelectedPlayer)
                {
                    item.UnselectPlayer();
                }
                flpAllTeamPlayers.Controls.Remove(item);
                flpFavoritePlayers.Controls.Add(item);
                item.ShowStar();
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        //Save i ranklist
        private void btncClose_Click(object sender, EventArgs e)
        {
            CloseForm closeForm = new CloseForm();
            closeForm.ShowDialog();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {
            selectedCountry = cbTeams.SelectedItem as Countries;
            string fifaCode = selectedCountry.FifaCode;
            string country = selectedCountry.Country;

            SaveChampionshipData(championShipFile, cbTeams.SelectedItem as Countries);
            SaveFavoritePlayersData(favoritePlayersFile, flwFavPlayer.Controls.Cast<PlayerControl>().ToList());

            RankFrom rankForm = new RankFrom(country, fifaCode);

            rankForm.Show();
            this.Hide();
        }



        private void SaveChampionshipData(string championshipFile, Countries selectedCountry)
        {
            try
            {


                File.WriteAllText(championshipFile, selectedCountry.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void SaveFavoritePlayersData(string favoritePlayersFile, List<PlayerControl> favoritePlayers)
        {
            try
            {

                var playerLines = favoritePlayers.Select(item => item.GetPlayer().ToString()).ToArray();
                File.WriteAllLines(favoritePlayersFile, playerLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }


    }
}