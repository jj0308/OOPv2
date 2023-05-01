using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class MatchData
    {
        public List<MatchPlayed> MatchPlayed { get; set; }
        public List<Player> StartingEleven { get; set; }
    }
}
