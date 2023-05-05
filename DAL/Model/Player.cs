using Newtonsoft.Json;

namespace DAL.Model
{
    public class Player : IComparable<Player>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        public string Goals { get; set; }

        public string YellowCards { get; set; }

        public string Appearances { get; set; }

        public int GoalsPerMatch { get; set; }

        public int YellowCardsPerMatch { get; set; }

        public bool FavouritePlayer { get; set; }

        public string Image { get; set; }
       

       

        public int CompareTo(Player other) => -Goals.CompareTo(other.Goals);
        public int CompareToYellowCard(Player other) => -YellowCards.CompareTo(other.YellowCards);

        public override bool Equals(object obj) => obj is Player other ? Name == other.Name : false;
        public override int GetHashCode() => Name.GetHashCode();

    }
}
