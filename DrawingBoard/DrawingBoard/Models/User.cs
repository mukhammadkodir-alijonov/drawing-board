namespace DrawingBoard.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public ICollection<Board> Boards { get; set; }
    }
}
