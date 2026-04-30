namespace planuApp.Models
{
    public class Room
    {
        public required string RoomId { get; set; }
        public required string ModeratorId { get; set; }
        public List<Player> Players { get; set; } = new();
        public string CardSeriesType { get; set; } = "Fibonacci";
        public List<string> CustomCardSeries { get; set; } = new();
        public bool CardsRevealed { get; set; }
        public string Topic { get; set; } = string.Empty;
        public bool OnlyModeratorCanReveal { get; set; } = false;
        
        // Timer features
        public int? TimerSeconds { get; set; }
        public bool IsTimerRunning { get; set; }
        
        public List<string> GetAvailableCards()
        {
            return CardSeriesType switch
            {
                "Fibonacci" => new List<string> { "0", "1", "2", "3", "5", "8", "13", "21", "34", "55", "89", "?", "Coffee" },
                "Normal" => new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "?", "Coffee" },
                "Other" => CustomCardSeries.Any() ? CustomCardSeries : new List<string> { "1", "2", "3" },
                _ => new List<string> { "0", "1", "2", "3", "5", "8", "13", "21", "?", "Coffee" }
            };
        }
    }
}
