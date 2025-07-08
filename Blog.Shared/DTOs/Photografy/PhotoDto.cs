namespace Blog.Shared.DTOs.Photografy
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public DateTime DateTaken { get; set; }
        public List<string> Tags { get; set; }
    }
}
