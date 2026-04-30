namespace planuApp.Models
{
    public class Player
    {
        public required string ConnectionId { get; set; }
        public required string Name { get; set; }
        public string? SelectedCard { get; set; }
        public bool IsModerator { get; set; }
    }
}
