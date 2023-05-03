using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Constants
{
    public class Constants
    {
        public const string Goal = "goal";
        public const string GoalPenalty = "goal-penalty";
        public const string YellowCard = "yellow-card";
        public const string SubstitutionIn = "substitution-in";
        public const string FilePath = "RankingsReport.pdf";

        public const char DEL = '|';

        public const string HR = "hr";
        public const string EN = "en";
        public const string MEN = "men";
        public const string WOMEN = "women";


        public const string COUNTRYMEN = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string COUNTRYWOMEN = "https://worldcup-vua.nullbit.hr/women/teams/results";

        public const string MATCHMEN = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
        public const string MATCHWOMEN = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
       

        public const string FAVTEAM_MEN = @"../../Files/favTeamMen.txt";
        public const string FAVPLAYERS_MEN = @"../../Files/favPlayersMen.txt";

        public const string FAVTEAM_WOMEN = @"../../Files/favTeamWoman.txt";
        public const string FAVPLAYERS_WOMEN = @"../../Files/favPlayersWoman.txt";

        public const string PREF_LANG = @"../../Files/pref_lang.txt";
        public const string PREF_CHAMP = @"../../Files/pref_champ.txt";

        //WPF
        public const string PREF_RESOLUTION = @"..\..\..\..\WFA\bin\Files\resolution.txt";
        public const string PREF_LANG_WPF = @"..\..\..\..\WFA\bin\Files\pref_lang.txt";
        public const string PREF_CHAMP_WPF = @"..\..\..\..\WFA\bin\Files\pref_champ.txt";
        public const string FAVTEAM_MEN_WPF = @"..\..\..\..\WFA\bin\Files\favTeamMen.txt";
        public const string FAVTEAM_WOMEN_WPF = @"..\..\..\..\WFA\bin\Files\favTeamWoman.txt";


        //Images
        public const string PLAYERS_IMAGES = @"Players_images";
        public const string PLAYERS_IMAGES_WPF = @"\WFA\bin\Debug\Players_images";
       




        public static string GetLanguage()
        {
            if (File.ReadLines(PREF_LANG).FirstOrDefault() == "hr")
            {
                return HR;
                
    }
            else
            {
                return EN;
            }
        }

        public static string GetCountriesByGender()
        {
            if (File.ReadLines(PREF_CHAMP).FirstOrDefault() == "men" )
            {
                return COUNTRYMEN;
            }
            else
            {
                return COUNTRYWOMEN;
            }
        }


        public static string GetMatchesByGender()
        {
            if (File.ReadLines(PREF_CHAMP).FirstOrDefault() == "men")
            {
                return MATCHMEN;
            }
            else
            {
                return MATCHWOMEN;
            }

        }

       



    


    }
}
