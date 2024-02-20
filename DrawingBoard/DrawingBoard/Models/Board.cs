namespace DrawingBoard.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; } // Base64 encoded thumbnail
        public ICollection<Drawing> Drawings { get; set; }
        public User User { get; set; }
    }
}
