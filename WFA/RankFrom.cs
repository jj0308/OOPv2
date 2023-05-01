using DAL;
using DAL.Model;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Document = iText.Layout.Document;
using System.Windows.Forms;
using DAL.Repo;
using DAL.Constants;

namespace WFA
{
    public partial class RankFrom : Form
    {



        private Dictionary<Player, Player> playerStats = new Dictionary<Player, Player>();
        private List<SoccerMatch> soccerMatches = new List<SoccerMatch>();

        public RankFrom()
        {
            SetSettings.SetCulture(File.ReadLines(Constants.PREF_LANG).FirstOrDefault());
            InitializeComponent();
        }

        public RankFrom(object country, object fifaCode)
        {
            SetSettings.SetCulture(File.ReadLines(Constants.PREF_LANG).FirstOrDefault());
            InitializeComponent();
            SelectedCountry = country;
            SelectedFifaCode = fifaCode;

            FillPanelWithPlayersGoals((string)fifaCode, (string)country);
        }

        public object SelectedCountry { get; }
        public object SelectedFifaCode { get; }

        private async void FillPanelWithPlayersGoals(string fifaCode, string country)
        {
            WCREPO wCRepo = new WCREPO();
            string link = Constants.GetMatchesByGender() + fifaCode;
            soccerMatches = await wCRepo.GetStats(link);
            DisplaySortedSoccerMatches();

            List<TeamEvent> allEvents = GetAllCountryEvents(soccerMatches, country);
            List<Player> startingEleven = GetStartingEleven(soccerMatches, country);
            CountPlayerEvents(allEvents, playerStats, startingEleven);
            DisplaySortedSoccerPlayers();
        }

        private async Task DisplaySortedSoccerMatches()
        {
            List<SoccerMatch> sortedSoccerMatches = rbAudienceAsc.Checked
                ? soccerMatches.OrderBy(match => match.Attendance).ToList()
                : soccerMatches.OrderByDescending(match => match.Attendance).ToList();

            pnlMatches.Controls.Clear();

            foreach (var item in sortedSoccerMatches)
            {
                RankMatchFrom rankMatchFrom = new RankMatchFrom(new SoccerMatch
                {
                    Venue = item.Venue,
                    HomeTeam = item.HomeTeam,
                    AwayTeam = item.AwayTeam,
                    Attendance = item.Attendance
                });

                await Console.Out.WriteLineAsync(item.Venue);
                pnlMatches.Controls.Add(rankMatchFrom);
            }
        }



        private List<Player> GetStartingEleven(List<SoccerMatch> soccerMatches, string country)
        {
            List<Player> startingEleven = new List<Player>();

            foreach (var match in soccerMatches)
            {
                if (match.HomeTeam.Country == country)
                {
                    startingEleven.AddRange(match.HomeTeamStatistics.StartingEleven);
                }
                if (match.AwayTeam.Country == country)
                {
                    startingEleven.AddRange(match.AwayTeamStatistics.StartingEleven);
                }
            }

            return startingEleven;
        }



        private List<TeamEvent> GetAllCountryEvents(List<SoccerMatch> soccerMatches, string country)
        {
            List<TeamEvent> countryEvents = new List<TeamEvent>();

            foreach (var match in soccerMatches)
            {
                if (match.HomeTeam.Country == country)
                {
                    countryEvents.AddRange(match.HomeTeamEvents);
                }
                if (match.AwayTeam.Country == country)
                {
                    countryEvents.AddRange(match.AwayTeamEvents);
                }
            }

            return countryEvents;
        }


        private void CountPlayerEvents(List<TeamEvent> events, Dictionary<Player, Player> playerStats, List<Player> startingEleven)
        {
            var startingElevenNames = startingEleven.Select(p => p.Name).ToList();
            var substitutesIn = events.Where(e => e.TypeOfEvent == Constants.SubstitutionIn).Select(e => e.Player).ToList();

            foreach (var playerName in startingElevenNames.Concat(substitutesIn))
            {
                Player existingPlayer = playerStats.Keys.FirstOrDefault(p => p.Name == playerName);

                if (existingPlayer == null)
                {
                    Player newPlayer = new Player
                    {
                        Name = playerName,
                        Goals = "0",
                        YellowCards = "0",
                        Appearances = "0"
                    };

                    playerStats.Add(newPlayer, newPlayer);
                }
                else
                {
                    Player stats = playerStats[existingPlayer];
                    stats.Appearances = (int.Parse(stats.Appearances) + 1).ToString();
                }
            }

            var groupedEvents = events.GroupBy(e => e.Player);

            foreach (var group in groupedEvents)
            {
                string playerName = group.Key;

                int goals = group.Count(e => e.TypeOfEvent == Constants.Goal || e.TypeOfEvent == Constants.GoalPenalty);
                int yellowCards = group.Count(e => e.TypeOfEvent == Constants.GoalPenalty);

                Player existingPlayer = playerStats.Keys.FirstOrDefault(p => p.Name == playerName);

                if (existingPlayer != null)
                {
                    Player stats = playerStats[existingPlayer];
                    stats.Goals = (int.Parse(stats.Goals) + goals).ToString();
                    stats.YellowCards = (int.Parse(stats.YellowCards) + yellowCards).ToString();
                }
                else
                {
                    Player newPlayer = new Player
                    {
                        Name = playerName,
                        Goals = goals.ToString(),
                        YellowCards = yellowCards.ToString(),
                        Appearances = "0"
                    };

                    playerStats.Add(newPlayer, newPlayer);
                }
            }
        }


        private void DisplaySortedSoccerPlayers()
        {
            lblSortPlayerMsg.Text = SetSettings.settings.Language == "en" ? "I'm sorting players..." : "Sortiram igrace...";
            Dictionary<Player, Player> sortedPlayers = playerStats.ToDictionary(kv => kv.Key, kv => kv.Value);

            if (rbGoalsAsc.Checked)
            {
                sortedPlayers = sortedPlayers.OrderBy(player => player.Value.Goals).ToDictionary(kv => kv.Key, kv => kv.Value);
            }
            else if (rbGoalsDesc.Checked)
            {
                sortedPlayers = sortedPlayers.OrderByDescending(player => player.Value.Goals).ToDictionary(kv => kv.Key, kv => kv.Value);
            }
            else if (rbYcAsc.Checked)
            {
                sortedPlayers = sortedPlayers.OrderBy(player => player.Value.YellowCards).ToDictionary(kv => kv.Key, kv => kv.Value);
            }
            else if (rbYCDDesc.Checked)
            {
                sortedPlayers = sortedPlayers.OrderByDescending(player => player.Value.YellowCards).ToDictionary(kv => kv.Key, kv => kv.Value);
            }

            pnlPlayers.Controls.Clear();

            foreach (var item in sortedPlayers)
            {
                Player player = new Player
                {
                    Name = item.Key.Name,
                    YellowCards = item.Value.YellowCards,
                    Goals = item.Value.Goals,
                    Appearances = item.Value.Appearances,
                    Image = item.Key.Image
                };

                RankPlayer rankPlayer = new RankPlayer(player);
                pnlPlayers.Controls.Add(rankPlayer);
            }
            lblSortPlayerMsg.Text = "";
        }



        private void rbYCDDesc_CheckedChanged(object sender, EventArgs e)
        {
            DisplaySortedSoccerPlayers();
        }

        private void rbYcAsc_CheckedChanged(object sender, EventArgs e)
        {
            DisplaySortedSoccerPlayers();
        }

        private void rbGoalsAsc_CheckedChanged(object sender, EventArgs e)
        {
            DisplaySortedSoccerPlayers();
        }

        private void rbGoalsDesc_CheckedChanged(object sender, EventArgs e)
        {
            DisplaySortedSoccerPlayers();
        }

        private void rbAudienceAsc_CheckedChanged(object sender, EventArgs e)
        {
            //lblMsg = "Sortiram igrace";
            DisplaySortedSoccerMatches();
        }

        private void rbAudienceDesc_CheckedChanged(object sender, EventArgs e)
        {
            DisplaySortedSoccerMatches();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "PDF Files|*.pdf";
                saveFileDialog1.Title = "Save the PDF Report";
                saveFileDialog1.FileName = "SoccerRankingsReport.pdf";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog1.FileName;
                    List<Player> players = GetPlayersFromPanel();
                    List<SoccerMatch> matches = GetMatchesFromPanel();
                    GeneratePdfReport(players, matches, filePath);
                    MessageBox.Show("PDF report has been generated and saved successfully.", "Report Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private List<SoccerMatch> GetMatchesFromPanel()
        {
            List<SoccerMatch> matches = new List<SoccerMatch>();

            foreach (Control control in pnlMatches.Controls)
            {
                if (control is RankMatchFrom rankMatchFrom)
                {
                    SoccerMatch match = new SoccerMatch
                    {
                        Venue = rankMatchFrom.LocationText,
                        HomeTeam = new Team { Country = rankMatchFrom.HomeTeamText },
                        AwayTeam = new Team { Country = rankMatchFrom.AwayTeamText },
                        Attendance = rankMatchFrom.AttendanceText
                    };
                    matches.Add(match);
                }
            }

            return matches;
        }


        private List<Player> GetPlayersFromPanel()
        {
            List<Player> players = new List<Player>();

            foreach (Control control in pnlPlayers.Controls)
            {
                if (control is RankPlayer rankPlayer)
                {
                    string playerName = rankPlayer.PlayerName;
                    int playerGoals = rankPlayer.PlayerGoals;
                    int playerYellowCards = rankPlayer.PlayerYellowCards;
                    int playerAppearances = rankPlayer.PlayerAppearances;

                    players.Add(new Player
                    {
                        Name = playerName,
                        Goals = playerGoals.ToString(),
                        YellowCards = playerYellowCards.ToString(),
                        Appearances = playerAppearances.ToString()
                    });
                }
            }

            return players;
        }




        private void GeneratePdfReport(List<Player> players, List<SoccerMatch> matches, string filePath)
        {
            using (var writer = new PdfWriter(filePath))
            {

                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    // Add title
                    var title = new Paragraph("Soccer Rankings Report")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(24);
                    document.Add(title);

                    if (tabControl.SelectedTab == tabPlayers)
                    {
                        document.Add(new Paragraph("Players").SetFontSize(18));
                        var playersTable = new Table(UnitValue.CreatePercentArray(new float[] { 25, 25, 25, 25 }));
                        playersTable.AddHeaderCell("Name");
                        playersTable.AddHeaderCell("Appearances");
                        playersTable.AddHeaderCell("Goals");
                        playersTable.AddHeaderCell("Yellow Cards");


                        foreach (var player in players)
                        {
                            playersTable.AddCell(player.Name);
                            playersTable.AddCell(player.Appearances.ToString());
                            playersTable.AddCell(player.Goals.ToString());
                            playersTable.AddCell(player.YellowCards.ToString());

                        }

                        document.Add(playersTable);
                        document.Close();
                    }
                    if (tabControl.SelectedTab == tabMatches)
                    {
                        document.Add(new Paragraph("Matches").SetFontSize(18));
                        var matchesTable = new Table(UnitValue.CreatePercentArray(new float[] { 25, 25, 25, 25 }));
                        matchesTable.AddHeaderCell("Venue");
                        matchesTable.AddHeaderCell("Attendance");
                        matchesTable.AddHeaderCell("Home Team");
                        matchesTable.AddHeaderCell("Away Team");


                        foreach (var match in matches)
                        {
                            matchesTable.AddCell(match.Venue);
                            matchesTable.AddCell(match.Attendance.ToString());
                            matchesTable.AddCell(match.HomeTeam.Country);
                            matchesTable.AddCell(match.AwayTeam.Country);

                        }
                        document.Add(matchesTable);
                        document.Close();
                    }
                }
            }
        }

        private void changeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
            this.Close();
        }
    }
}