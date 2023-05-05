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

namespace WPF
{
    public partial class MainWindow : Window
    {
        private const char DEL = 'X';
        private List<SoccerMatch> soccerMatch = new List<SoccerMatch>();
        private List<Countries> countriesAll = new List<Countries>();
        private List<Countries> awayCountries = new List<Countries>();

        public MatchData matchData;

        string championShipFile;
        string favMenTeam;
        string favWomenTeam;
        string resolution;
        string favLang;
        Countries selectedHomeCountry;
        Countries selectedAwayCountry;
        private string homeCountry;

        public MainWindow()
        {
            //CheckIfFilesExits();
            SetCultureFromFile();
            InitializeComponent();
        }

        private void CheckIfFilesExits()
        {
            throw new NotImplementedException();
        }

        //Postavljanje jezika iz file-a
        private void SetCultureFromFile()
        {
            try
            {

                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativeFilePath = Constants.PREF_LANG_WPF;
                string fullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDirectory, relativeFilePath));


                if (new FileInfo(fullPath).Length != 0)
                {
                        var lines = File.ReadAllLines(fullPath);
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

                resolution = Constants.PREF_RESOLUTION;
                
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                

                 championShipFile = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, Constants.PREF_CHAMP_WPF));


                favMenTeam = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, Constants.FAVTEAM_MEN_WPF));
                favWomenTeam = System.IO.Path.GetFullPath(System.IO.Path.Combine(baseDirectory, Constants.FAVTEAM_MEN_WPF));


                lblInfo.Content = "Dohvaćam podatke";

                if (new FileInfo(resolution).Length != 0)
                {
                 var lines = File.ReadAllLines(resolution);
                GetResolutionFromFile(lines);
                
               
                    CenterWindowOnScreen();
                }


                    if (new FileInfo(championShipFile).Length != 0)
                
                    {
                        var lines = File.ReadAllLines(championShipFile);
                        string s = string.Join("", lines);

                    if (s == Constants.MEN)
                    {
                        if (new FileInfo(favMenTeam).Length != 0)
                        {
                            SetSettings.settings.Gender = Constants.MEN;
                            var linesMenTeam = File.ReadAllLines(favMenTeam);
                            await GetCountriesFromFile(Constants.COUNTRYMEN);

                            GetFavoriteTeamFromFile(linesMenTeam);
                    
                    }
                }
                    else
                    {
                        if (new FileInfo(favWomenTeam).Length != 0)
                        {
                            SetSettings.settings.Gender = Constants.WOMEN;
                            var linesWomenTeam = File.ReadAllLines(favWomenTeam);
                            await GetCountriesFromFile(Constants.COUNTRYWOMEN);
                            GetFavoriteTeamFromFile(linesWomenTeam);
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

        //Centriranje prozora u sredinu ekrana
        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        //Dohvat timova
        private async Task GetCountriesFromFile(string path)
        {
            try
            {
                WCREPO wCREPO = new WCREPO();
                countriesAll = await wCREPO.GetAllCountries(Constants.COUNTRYMEN);
                foreach (var item in countriesAll)
                {
                    cbHomeTeam.Items.Add(item);
                }
                lblInfo.Content = string.Empty;
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
                var fifa_code = data[1].Substring(1, data[1].Length - 2);
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
                homeCountry = country + $" (" + fifa_code + $")";
                cbAwayTeam.Items.Clear();

                GetOpponentTeams(matchData, country);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} ode puca ");
            }
        }

        //Dohvat svih utakmica za odabrani tim
        private MatchData GetMatchData(List<SoccerMatch> soccerMatch, string country)
        {
            MatchData matchData = new MatchData
            {
                StartingEleven = soccerMatch[0].HomeTeamStatistics.StartingEleven.ToList(),
                MatchPlayed = new List<MatchPlayed>()
            };

            foreach (var item in soccerMatch)
            {
                var match = new MatchPlayed();

                if (item.HomeTeamCountry == country)
                {
                    match.HomeTeamCountry = item.HomeTeamCountry;
                    match.HomePlayers = GetEvents(item.HomeTeamStatistics.StartingEleven.ToList(), item.HomeTeamEvents);
                    match.HomesGoals = item.HomeTeam.Goals;
                }
                else
                {
                    match.AwayTeamCountry = item.HomeTeamCountry;
                    match.AwaysPlayers = GetEvents(item.HomeTeamStatistics.StartingEleven.ToList(), item.HomeTeamEvents);
                    match.AwaysGoals = item.HomeTeam.Goals;
                }

                if (item.AwayTeamCountry == country)
                {
                    match.HomeTeamCountry = item.AwayTeamCountry;
                    match.HomePlayers = GetEvents(item.AwayTeamStatistics.StartingEleven.ToList(), item.AwayTeamEvents);
                    match.HomesGoals = item.AwayTeam.Goals;
                }
                else
                {
                    match.AwayTeamCountry = item.AwayTeamCountry;
                    match.AwaysPlayers = GetEvents(item.AwayTeamStatistics.StartingEleven.ToList(), item.AwayTeamEvents);
                    match.AwaysGoals = item.AwayTeam.Goals;
                }
                matchData.MatchPlayed.Add(match);
            }

            return matchData;
        }

        //Dohvat evenata igrača (goal i yellow card)
        private List<Player> GetEvents(List<Player> playersList, List<TeamEvent> teamEvents)
        {
            List<Player> playersEvent = playersList;
            foreach (var item in teamEvents)
            {
                Player playerEvent = (from player in playersList
                                      where player.Name == item.Player
                                      select player).FirstOrDefault();

                foreach (var pl in playersList)
                {
                    if (pl.Name == item.Player)
                    {
                        if (item.TypeOfEvent == "yellow-card")
                        {
                            ++playerEvent.YellowCardsPerMatch;
                        }
                        if (item.TypeOfEvent == "goal-penalty")
                        {
                            ++playerEvent.GoalsPerMatch;
                        }
                        if (item.TypeOfEvent == "goal")
                        {
                            ++playerEvent.GoalsPerMatch;
                        }
                    }
                }
            }
            return playersEvent;
        }

        //Dohvat Home tima
        private void GetHomeTeam(MatchData matchData, string country)
        {
            foreach (var item in matchData.StartingEleven)
            {
                PlayerControl playerControl = new PlayerControl(new Player
                {
                    Name = item.Name,
                    ShirtNumber = item.ShirtNumber,
                    Position = item.Position,
                    Image = item.Image,
                    Goals = item.GoalsPerMatch.ToString(),
                    YellowCards = item.YellowCardsPerMatch.ToString()
                });
                PopulateHomeTeamPlayers(item, playerControl);
            }
        }

        //Dohvat oba tima 
        private void GetTeamsFromMatch(MatchData matchData, string country)
        {
            foreach (var item in matchData.MatchPlayed)
            {
                if (item.AwayTeamCountry == country)
                {
                    foreach (var p in item.AwaysPlayers)
                    {
                        PlayerControl playerControl = new PlayerControl(new Player
                        {
                            Name = p.Name,
                            ShirtNumber = p.ShirtNumber,
                            Position = p.Position,
                            Image = p.Image,
                            Goals = p.GoalsPerMatch.ToString(),
                            YellowCards = p.YellowCardsPerMatch.ToString()
                        }); ;
                        PopulateAwayTeamPlayers(p, playerControl);
                    }
                    foreach (var p in item.HomePlayers)
                    {
                        PlayerControl playerControl = new PlayerControl(new Player
                        {
                            Name = p.Name,
                            ShirtNumber = p.ShirtNumber,
                            Position = p.Position,
                            Image = p.Image,
                            Goals = p.GoalsPerMatch.ToString(),
                            YellowCards = p.YellowCardsPerMatch.ToString()
                        });

                        PopulateHomeTeamPlayers(p, playerControl);
                    }
                    lblHomeGoals.Content = item.HomesGoals.ToString();
                    lblAwayGoals.Content = item.AwaysGoals.ToString();
                }
            }
        }

        //Popunjavanje Home tima s igračima
        private void PopulateHomeTeamPlayers(Player item, PlayerControl playerControl)
        {
            if (item.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerControl, 0);
                Grid.SetRow(playerControl, 2);
                spGoalkeeperHome.Children.Add(playerControl);
            }

            if (item.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerControl, 1);
                Grid.SetRow(playerControl, 2);
                spDefenderHome.Children.Add(playerControl);
            }

            if (item.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerControl, 2);
                Grid.SetRow(playerControl, 2);
                spMidfielderHome.Children.Add(playerControl);
            }

            if (item.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerControl, 3);
                Grid.SetRow(playerControl, 2);
                spForwardHome.Children.Add(playerControl);
            }
        }

        //Popunjavanje Away tima s igračima
        private void PopulateAwayTeamPlayers(Player p, PlayerControl playerControl)
        {
            if (p.Position.Equals("Goalie"))
            {
                Grid.SetColumn(playerControl, 7);
                Grid.SetRow(playerControl, 2);
                spGoalkeeperGuests.Children.Add(playerControl);
            }

            if (p.Position.Equals("Defender"))
            {
                Grid.SetColumn(playerControl, 6);
                Grid.SetRow(playerControl, 2);
                spDefenderGuests.Children.Add(playerControl);
            }

            if (p.Position.Equals("Midfield"))
            {
                Grid.SetColumn(playerControl, 5);
                Grid.SetRow(playerControl, 2);
                spMidfielderGuests.Children.Add(playerControl);
            }

            if (p.Position.Equals("Forward"))
            {
                Grid.SetColumn(playerControl, 4);
                Grid.SetRow(playerControl, 2);
                spForwardGuests.Children.Add(playerControl);
            }
        }

        //Dohvat suparničkog tima
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

        //Popunjavanje Team Info prozora
        private TeamInfo GetTeamStatistics(string country)
        {
            TeamInfo teamInfo = new TeamInfo();
            foreach (var item in countriesAll)
            {
                if (item.Country == country)
                {
                    teamInfo.lblCountry.Content = item.Country;
                    teamInfo.lblWins.Content = item.Wins;
                    teamInfo.lblDraws.Content = item.Draws;
                    teamInfo.lblGamesPlayed.Content = item.GamesPlayed;
                    teamInfo.lblPoints.Content = item.Points;
                    teamInfo.lblGoalsFor.Content = item.GoalsFor;
                    teamInfo.lblGoalsAgainst.Content = item.GoalsAgainst;
                    teamInfo.lblGoalsDifferences.Content = item.GoalDifferential;
                }
            }
            return teamInfo;
        }

        //Settings
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            this.Close();
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

    }
}
