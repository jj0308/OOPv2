using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public interface IWCREPO
    {

        Task<List<Countries>> GetAllCountries(string country);
        Task<List<SoccerMatch>> GetAllTeamPlayers(string fifa_code);
        Task<List<SoccerMatch>> GetStats(string fifa_code);
    }
}
