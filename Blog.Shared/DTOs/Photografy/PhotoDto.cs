namespace Blog.Shared.DTOs.Photografy
{
    public class PhotoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTaken { get; set; }
        public List<string> Tags { get; set; }
    }
}
