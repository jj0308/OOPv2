using DAL;
using DAL.Constants;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.IO;
using System.Numerics;

namespace WPF
{
    public partial class MainWindow : Window
    {
        private const char DEL = 'X';
        private List<SoccerMatch> soccerMatch = new List<SoccerMatch>();
        private List<Countries> countriesAll = new List<Countries>();
        private List<Countries> awayCountries = new List<Countries>();

        public MatchData matchData;

       
        Countries selectedHomeCountry;
        Countries selectedAwayCountry;
        private string homeCountry;
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string countrycb;
        private string codecb;


      
        public MainWindow()
        {
            CheckIfFilesExits();
            SetCultureFromFile();
            InitializeComponent();
        }

        private void CheckIfFilesExits()
        {
           
            string langfile = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, Constants.PREF_LANG_WPF));
            var championshipFilePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, Constants.PREF_CHAMP_WPF));
            var resolutionPath = Constants.PREF_RESOLUTION;

            if (!File.Exists(langfile))
            {
                OpenSettingsFrom();
            }
            if (!File.Exists(championshipFilePath))
            {
                OpenSettingsFrom();
            }
            if (!File.Exists(resolutionPath))
            {
                OpenSettingsFrom();
            }

        }
        private void OpenSettingsFrom()
        {
            Settings settings = new Settings();
            settings.Show();
            this.Close();
        }



        //Postavljanje jezika iz file-a
        private void SetCultureFromFile()
        {
            try
            {


                string relativeFilePath = Constants.PREF_LANG_WPF;
                string langfile = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, relativeFilePath));


                if (new FileInfo(langfile).Length != 0)
                {
                        var lines = File.ReadAllLines(langfile);
                        GetFavoriteLang(lines);
                           
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} jel tu");
            }
        }
      
        private void GetFavoriteLang(string[] lines)
        {
            foreach (var line in lines)
            { 
                
                if (line == Constants.HR)
                {
                    SetSettings.settings.Language = Constants.HR;
                    SetSettings.SetCulture(Constants.HR);
                }
                if (line == Constants.EN)
                {
                    SetSettings.settings.Language = Constants.EN;
                    SetSettings.SetCulture(Constants.EN);
                }
            }
        }

        //Dohvaćam podatke o CUP i GENDER - popunjavam combobox sa timovima
        private async void Window_ContentRendered(object sender, EventArgs e)
        {
            try
            {
                var resolutionPath = Constants.PREF_RESOLUTION;
                var championshipFilePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, Constants.PREF_CHAMP_WPF));
                var favoriteMenTeamPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, Constants.FAVTEAM_MEN_WPF));
                var favoriteWomenTeamPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, Constants.FAVTEAM_WOMEN_WPF));

                lblInfo.Content = "Fetching data";

                if (File.Exists(resolutionPath))
                {
                    var resolutionLines = File.ReadAllLines(resolutionPath);
                    GetResolutionFromFile(resolutionLines);
                }

                if (File.Exists(championshipFilePath))
                {
                    var championshipLines = File.ReadAllLines(championshipFilePath);
                    var championshipText = string.Join("", championshipLines);

                    if (championshipText == Constants.MEN)
                    {
                        if (File.Exists(favoriteMenTeamPath))
                        {
                            SetSettings.settings.Gender = Constants.MEN;
                            var favoriteMenTeamLines = File.ReadAllLines(favoriteMenTeamPath);
                            await GetCountriesFromFile();
                            GetFavoriteTeamFromFile(favoriteMenTeamLines);
                        }
                    }
                    else
                    {
                        if (File.Exists(favoriteWomenTeamPath))
                        {
                            SetSettings.settings.Gender = Constants.WOMEN;
                            var favoriteWomenTeamLines = File.ReadAllLines(favoriteWomenTeamPath);
                            await GetCountriesFromFile();
                            GetFavoriteTeamFromFile(favoriteWomenTeamLines);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }


        //Dohvat rezolucije
        private void GetResolutionFromFile(string[] lines)
        {
            if (lines == null)
            {
                return;
            }

            foreach (var line in lines)
            {
                if (line == "Full-Screen")
                {
                    WindowState = WindowState.Maximized;
                }
                else
                {
                    string[] details = line.Split(DEL);
                    int x, y;

                    if (int.TryParse(details[0], out x) && int.TryParse(details[1], out y))
                    {
                        this.Width = x;
                        this.Height = y;
                    }
                }
            }
        }

     

        //Dohvat timova
        private async Task GetCountriesFromFile()
        {
            try
            {
                WCREPO wCREPO = new WCREPO();
                countriesAll = await wCREPO.GetAllCountries(Constants.GetCountiresByGenderWPF());
                foreach (var item in countriesAll)
                {
                    cbHomeTeam.Items.Add(item);
                }

                var matchingCountry = cbHomeTeam.Items.OfType<Countries>()
                       .FirstOrDefault(c => c.Country == countrycb && c.FifaCode == codecb);

                if (matchingCountry != null)
                {
                    cbHomeTeam.SelectedItem = matchingCountry;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Dohvat omiljenog tima iz file-a 
        private void GetFavoriteTeamFromFile(string[] lines)
        {
            foreach (var line in lines)
            {
                string[] data = line.Split(' ');
                var countryHome = data[0];

                //micemo zagrade
                var fifa_code = data[1].Substring(1, data[1].Length - 2);

               
                countrycb = countryHome;
                codecb = fifa_code;

               
              
                GetDataPerMatch(fifa_code, countryHome);
            }
        }

        //Popunjavanje igračima omiljenog tima
        private async void GetDataPerMatch(string fifa_code, string country)
        {
            try
            {
                WCREPO wCREPO = new WCREPO();
                string link = Constants.GetMatchesByGenderWPF() + fifa_code;
             


                soccerMatch = await wCREPO.GetStats(link);

                matchData = GetMatchData(soccerMatch, country);

                GetHomeTeam(matchData, country);
               

                cbAwayTeam.Items.Clear();
                
                GetOpponentTeams(matchData, country);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} ode puca ");
            }
        }

        //Dohvat svih utakmica koje je tim odigra i prvih 11
        private MatchData GetMatchData(List<SoccerMatch> soccerMatches, string country)
        {
            var matchData = new MatchData
            {
                StartingEleven = soccerMatches[0].HomeTeamStatistics.StartingEleven.ToList(),
                MatchPlayed = new List<MatchPlayed>()
            };
        

            foreach (var sM in soccerMatch)
            {
                var match = new MatchPlayed();

                if (sM.HomeTeamCountry == country)
                {
                    match.HomeTeamCountry = sM.HomeTeamCountry;
                    match.HomePlayers = GetPlayerEvents(sM.HomeTeamStatistics.StartingEleven.ToList(), sM.HomeTeamEvents);
                    match.HomesGoals = sM.HomeTeam.Goals;

                    match.AwayTeamCountry = sM.AwayTeamCountry;
                    match.AwaysPlayers = GetPlayerEvents(sM.AwayTeamStatistics.StartingEleven.ToList(), sM.AwayTeamEvents);
                    match.AwaysGoals = sM.AwayTeam.Goals;
                }
                else
                {
                    match.HomeTeamCountry = sM.AwayTeamCountry;
                    match.HomePlayers = GetPlayerEvents(sM.AwayTeamStatistics.StartingEleven.ToList(), sM.AwayTeamEvents);
                    match.HomesGoals = sM.AwayTeam.Goals;

                    match.AwayTeamCountry = sM.HomeTeamCountry;
                    match.AwaysPlayers = GetPlayerEvents(sM.HomeTeamStatistics.StartingEleven.ToList(), sM.HomeTeamEvents);
                    match.AwaysGoals = sM.HomeTeam.Goals;

                   
                }
            

               
                matchData.MatchPlayed.Add(match);
            }

            return matchData;
        }


        //Dohvat evenata igrača (goal i yellow card)
        private List<Player> GetPlayerEvents(List<Player> playersList, List<TeamEvent> teamEvents)
        {
            var playersWithEvents = playersList;
            var var = teamEvents;
            var filteredTeamEvents = teamEvents.Where(e => e.TypeOfEvent == "yellow-card" || e.TypeOfEvent == "goal-penalty" || e.TypeOfEvent == "goal").ToList();

          

            foreach (var teamEvent in filteredTeamEvents)
            {
               
                
                var playerEvent = playersList.FirstOrDefault(player => player.Name == teamEvent.Player);


                if (playerEvent != null)
                {
                    
                    if ( teamEvent.TypeOfEvent == "yellow-card")
                    {
                        playerEvent.YellowCardsPerMatch++;
                    }
                   
                    else if (teamEvent.TypeOfEvent == "goal-penalty" || teamEvent.TypeOfEvent == "goal")
                    {
                        playerEvent.GoalsPerMatch++;
                    }

                }
            }

            return playersWithEvents;
        }


        //Dohvat Home tima
        private void GetHomeTeam(MatchData matchData, string country)
        {
            foreach (var item in matchData.StartingEleven)
            {
                PlayerControl playerControl = new PlayerControl(new Player
                {
                    Name = item.Name,
                    Captain= item.Captain,
                    ShirtNumber = item.ShirtNumber,
                    Position = item.Position,
                    Image = item.Image,
                    Goals = item.GoalsPerMatch.ToString(),
                    YellowCards = item.YellowCardsPerMatch.ToString()
                });

            }
        }

        //Dohvat oba tima 
        private void GetTeamsFromMatch(MatchData matchData, string country)
        {
            foreach (var match in matchData.MatchPlayed)
            {
                if (match.AwayTeamCountry == country)
                {
                    foreach (var player in match.AwaysPlayers)
                    {
                        PlayerControl playerControl = new PlayerControl(new Player
                        {
                            Name = player.Name,
                            Captain = player.Captain,
                            ShirtNumber = player.ShirtNumber,
                            Position = player.Position,
                            Image = player.Image,
                            Goals = player.GoalsPerMatch.ToString(),
                            YellowCards = player.YellowCardsPerMatch.ToString()
                        }); ;
                        SetAwayPlayersToFiled(player, playerControl);
                    }
                    foreach (var player in match.HomePlayers)
                    {
                        PlayerControl playerControl = new PlayerControl(new Player
                        {
                            Name = player.Name,
                            Captain = player.Captain,
                            ShirtNumber = player.ShirtNumber,
                            Position = player.Position,
                            Image = player.Image,
                            Goals = player.GoalsPerMatch.ToString(),
                            YellowCards = player.YellowCardsPerMatch.ToString()
                        });

                        SetHomePlayersToFiled(player, playerControl);
                    }
                    lblHomeGoals.Content = match.HomesGoals.ToString();
                    lblAwayGoals.Content = match.AwaysGoals.ToString();
                }
            }
        }

        //Postavljanje domaceg tima na teretnu
        private void SetHomePlayersToFiled(Player player, PlayerControl playerControl)
        {
            if (player.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerControl, 0);
                Grid.SetRow(playerControl, 2);
                spGoalkeeperHome.Children.Add(playerControl);
            }

            if (player.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerControl, 1);
                Grid.SetRow(playerControl, 2);
                spDefenderHome.Children.Add(playerControl);
            }

            if (player.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerControl, 2);
                Grid.SetRow(playerControl, 2);
                spMidfielderHome.Children.Add(playerControl);
            }

            if (player.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerControl, 3);
                Grid.SetRow(playerControl, 2);
                spForwardHome.Children.Add(playerControl);
            }
        }

        //Postavljanje gostujuceg tima na teren
        private void SetAwayPlayersToFiled(Player player, PlayerControl playerControl)
        {
            if (player.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerControl, 7);
                Grid.SetRow(playerControl, 2);
                spGoalkeeperGuests.Children.Add(playerControl);
            }

            if (player.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerControl, 6);
                Grid.SetRow(playerControl, 2);
                spDefenderGuests.Children.Add(playerControl);
            }

            if (player.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerControl, 5);
                Grid.SetRow(playerControl, 2);
                spMidfielderGuests.Children.Add(playerControl);
            }

            if (player.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerControl, 4);
                Grid.SetRow(playerControl, 2);
                spForwardGuests.Children.Add(playerControl);
            }
        }



        //ode punimo combobox od away tima
        private void GetOpponentTeams(MatchData matchData, string country)
        {
            awayCountries.Clear();
            foreach (var item in matchData.MatchPlayed)
            {
                if (item.HomeTeamCountry != country)
                {
                    awayCountries.Add(countriesAll.FirstOrDefault(countriesAll => countriesAll.Country == item.HomeTeamCountry));
                }
                if (item.AwayTeamCountry != country)
                {
                    awayCountries.Add(countriesAll.FirstOrDefault(countriesAll => countriesAll.Country == item.AwayTeamCountry));
                }
            }
            cbAwayTeam.Items.Clear();

            foreach (var item in awayCountries)
            {
                cbAwayTeam.Items.Add(item);
            }
        }

   

        //Uklanjanje gostujućih igrača
        private void ClearGuestPlayers()
        {
            spGoalkeeperGuests.Children.Clear();
            spDefenderGuests.Children.Clear();
            spMidfielderGuests.Children.Clear();
            spForwardGuests.Children.Clear();
        }

        //Uklanjanje igrača domaćina
        private void ClearHomePlayers()
        {
            spGoalkeeperHome.Children.Clear();
            spDefenderHome.Children.Clear();
            spMidfielderHome.Children.Clear();
            spForwardHome.Children.Clear();
        }

        //ComboBox Home tim
        private void cbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedHomeCountry = cbHomeTeam.SelectedItem as Countries;
            try
            {
                if (cbHomeTeam.SelectedItem != null)
                {
                    ClearGuestPlayers();
                    ClearHomePlayers();
                    lblHomeGoals.Content = "0";
                    lblAwayGoals.Content = "0";

                    GetDataPerMatch(selectedHomeCountry.FifaCode, selectedHomeCountry.Country);
                    GetHomeTeam(matchData, selectedHomeCountry.Country);
                    cbAwayTeam.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //ComboBox Away tim
        private void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedAwayCountry = cbAwayTeam.SelectedItem as Countries;
            selectedHomeCountry = cbHomeTeam.SelectedItem as Countries;
            ClearGuestPlayers();
            ClearHomePlayers();
            lblHomeGoals.Content = "0";
            lblAwayGoals.Content = "0";
            try
            {
                if (cbAwayTeam.SelectedItem != null)
                {
                    GetTeamsFromMatch(matchData, selectedAwayCountry.Country);
                    GetTeamsFromMatch(matchData, homeCountry);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Info Home tim
        private void BtnInfoHomeTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbHomeTeam.SelectedItem != null)
                {
                    selectedHomeCountry = cbHomeTeam.SelectedItem as Countries;
                    TeamInfo teamInfo = GetTeamStatistics(selectedHomeCountry.Country);
                    teamInfo.Show();
                }
                else
                {
                    MessageBox.Show("You have to choose a team...", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cbHomeTeam.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //Info Away tim
        private void btnInfoGuestsTeam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbAwayTeam.SelectedItem != null)
                {
                    selectedAwayCountry = cbAwayTeam.SelectedItem as Countries;
                    TeamInfo teamInfo = GetTeamStatistics(selectedAwayCountry.Country);
                    teamInfo.Show();
                }
                else
                {
                    MessageBox.Show("You have to choose a team...", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    cbAwayTeam.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        //popunjavanje 
        private TeamInfo GetTeamStatistics(string country)
        {
            ///iz svih drzava izvucemo stattistiku Francuska ima 19 poena??????
            TeamInfo teamInfo = new TeamInfo();
            foreach (var team in countriesAll)
            {
                if (team.Country == country)
                {
                    teamInfo.lblCountry.Content = team.Country;
                    teamInfo.lblWins.Content = team.Wins;
                    teamInfo.lblDraws.Content = team.Draws;
                    teamInfo.lblGamesPlayed.Content = team.GamesPlayed;
                    teamInfo.lblPoints.Content = team.Points;
                    teamInfo.lblGoalsFor.Content = team.GoalsFor;
                    teamInfo.lblGoalsAgainst.Content = team.GoalsAgainst;
                    teamInfo.lblGoalsDifferences.Content = team.GoalDifferential;
                }
            }
            return teamInfo;
        }

       
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            OpenSettingsFrom();
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close close = new Close();
            close.ShowDialog();

            if (close.Result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

    }
}
