public class User
{
    public string Nickname { get; set; }
    public ICollection<Board> Boards { get; set; }
}

public class Board
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Thumbnail { get; set; } // Base64 encoded thumbnail
    public ICollection<Drawing> Drawings { get; set; }
    public User User { get; set; }
}

public class Drawing
{
    public int Id { get; set; }
    public string Type { get; set; } // e.g., "text", "rectangle", "circle"
    public string Color { get; set; }
    public string Content { get; set; } // e.g., the text or the coordinates of the shape
    public int BoardId { get; set; }
    public Board Board { get; set; }
}
