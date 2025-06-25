using Blog.Dataccess.Enums.DIY;
using Blog.Dataccess.Enums.Foods;

namespace Blog.Dataccess.Entities.DIY
{
    public class DIY
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DIYCategories Category { get; set; }
        public List<string> Components { get; set; }
        public string Instructions { get; set; }
    }
}
