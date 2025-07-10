namespace Blog.Dataccess.Entities.Photografy
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime DateTaken { get; set; }
        
    }
}
