namespace DrawingBoard.Models
{
    public class Drawing
    {
        public int Id { get; set; }
        public string Type { get; set; } // e.g., "text", "rectangle", "circle"
        public string Color { get; set; }
        public string Content { get; set; } // e.g., the text or the coordinates of the shape
        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
