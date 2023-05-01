using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class MatchPlayed
    {
        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        public List<Player> AwaysPlayers { get; set; }
        public List<Player> HomePlayers { get; set; }

        public int AwaysGoals { get; set; }
        public int HomesGoals { get; set; }
    }
}
