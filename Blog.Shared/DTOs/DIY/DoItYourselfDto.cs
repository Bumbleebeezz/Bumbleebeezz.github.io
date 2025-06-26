namespace Blog.Shared.DTOs.DIY
{
    public class DoItYourselfDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } 
        public List<string> Components { get; set; } = new List<string>();
        public string Instructions { get; set; }
    }
}
