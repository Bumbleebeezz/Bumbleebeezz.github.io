using Blog.Dataccess.Enums.DIY;

namespace Blog.Dataccess.Entities.DIY
{
    public class DoItYourself
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DIYCategories Category { get; set; }
        public List<string> Components { get; set; }
        public string Instructions { get; set; }
    }
}
