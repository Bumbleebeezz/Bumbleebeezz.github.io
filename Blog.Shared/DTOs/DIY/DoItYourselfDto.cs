namespace Blog.Shared.DTOs.DIY
{
    public class DoItYourselfDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string> Category { get; set; } = new List<string>();
        public List<string> Components { get; set; } = new List<string>();
        public string? Instructions { get; set; }
    }
}
