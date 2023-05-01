using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Countries
    {
        public Countries(string country, int wins, int draws, int losses, int gamesPlayed, int points, int goalsFor, int goalsAgainst, int goalDifferential)
        {
            Country = country;
            Wins = wins;
            Draws = draws;
            Losses = losses;
            GamesPlayed = gamesPlayed;
            Points = points;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            GoalDifferential = goalDifferential;
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("alternate_name")]
        public object AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string GroupLetter { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }

        [JsonProperty("draws")]
        public int Draws { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("games_played")]
        public int GamesPlayed { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goals_for")]
        public int GoalsFor { get; set; }

        [JsonProperty("goals_against")]
        public int GoalsAgainst { get; set; }

        [JsonProperty("goal_differential")]
        public int GoalDifferential { get; set; }

        public override string ToString()
        {
            return $"{Country} ({FifaCode})";
        }
    }
}
